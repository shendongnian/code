    namespace CastExample
    {
      class Program
      {
        static void Main(string[] args)
        {
            Employee emp = GetEmployee();
            FullTimeEmployee full = (FullTimeEmployee)emp;
            System.Console.WriteLine(full.AnnualSalary);
            PartTimeEmployee part = (PartTimeEmployee)emp;//InvalidCastException
            System.Console.ReadLine();
        }
        static Employee GetEmployee()
        {
            return new FullTimeEmployee() { Name = "George", AnnualSalary = 1234   };
        }
      }
      public class Employee
      {
         public string Name;
      }
      public class FullTimeEmployee : Employee
      {
         public int AnnualSalary { get; set; }
      }
      public class PartTimeEmployee : Employee
      {
          public int HourlyPay { get; set; }
          public int HoursWorked { get; set; }
      }
    }
