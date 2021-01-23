        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Linq;
        
        namespace AbundantCode  
        {
            internal class Program
            {
                //How to Remove Duplicates and Get Distinct records from List using LINQ ?
        
                private static void Main(string[] args)
                {
                    List<Employee> employees = new List<Employee>()
        {
        
        new Employee { EmpID = 1 , Name ="AC"},
        new Employee { EmpID = 2 , Name ="Peter"},
        new Employee { EmpID = 3 , Name ="Michael"},
        new Employee { EmpID = 3 , Name ="Michael"}
        };
                    
         //Gets the Distinct List
         var DistinctItems = employees.GroupBy(x => x.EmpID).Select(y => y.First());
                    foreach (var item in DistinctItems)
                    Console.WriteLine(item.Name);
                    Console.ReadLine();
                }
            }
        
            public class Employee
            {
                public string Name { get; set; }
                public int EmpID { get; set; }
            }
        }
