using System;
using System.Collections.Generic;
using System.IO;

class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
    public int Experience { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        List<Employee> employees = new List<Employee>();
        using (StreamReader reader = new StreamReader("employees.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');
                Employee employee = new Employee
                {
                    Name = data[0],
                    Salary = int.Parse(data[1]),
                    Experience = int.Parse(data[2])
                };
                employees.Add(employee);
            }
        }


        employees.Sort((x, y) => x.Salary.CompareTo(y.Salary));
        Console.WriteLine("Result of sorting by salary: ");

        foreach (Employee employee in employees)
        {
            Console.WriteLine("{0}: {1} hriven", employee.Name, employee.Salary);
        }
    }
}
