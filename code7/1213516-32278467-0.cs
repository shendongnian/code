    public class Employee
    {
        public int EmployeeID { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Employee ID:");
            var empID = int.Parse(Console.ReadLine());
            var employee1 = new Employee
            {
                EmployeeID = empID
            };
        }
    }
