    namespace Test
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        internal class Employee
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public double Salary { get; set; }
            public string Address { get; set; }
        }
    
        internal class Program
        {
            private static List<Employee> employees = new List<Employee>();
    
            private static void BuildList()
            {
                employees.AddRange(
                    new Employee[]
                        {
                            new Employee() {Name = "Tom", Age = 22, Address = "sample1", Salary = 10000},
                            new Employee() {Name = "Mithun", Age = 27, Address = "sample1", Salary = 20000},
                            new Employee() {Name = "Jasubhai", Age = 24, Address = "sample1", Salary = 12000},
                            new Employee() {Name = "Vinod", Age = 34, Address = "sample1", Salary = 30000},
                            new Employee() {Name = "Iqbal", Age = 52, Address = "sample1", Salary = 50000},
                            new Employee() {Name = "Gurpreet", Age = 22, Address = "sample1", Salary = 10000},
    
                        }
                    );
            }
    
            private static void Main(string[] args)
            {
                BuildList();
                var query = from employee in employees
                            where employee.Age < 27
                            select new
                                {
                                    A = employee.Name,
                                    B = employee.Age,
                                    C = employee.Salary
                                };
    
    
                var query2 = from employee in employees
                             where employee.Age > 27
                             select new
                                 {
                                     A = employee.Name,
                                     B = employee.Age,
                                     C = employee.Salary
                                 };
    
                var result = query.Concat(query2);
    
                foreach (dynamic item in result.ToArray())
                {
                    Console.WriteLine("Name = {0}, Age = {1}, Salary = {2}", item.A, item.B, item.C);
                }
            }
    
    
        }
    }
