    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = new List<Employee>
            {
                new Employee("Alex", 900000, 20000),
                new Employee("Lynda", 100000, 20000)
            };
            foreach (var employee in employees)
            {
                employee.CalculatePay();
            }
            Console.ReadKey();
        }
    }
    public class Employee
    {
        private readonly double _salary;
        private readonly double _bonus;
        private readonly string _name;
        public double Salary { get { return _salary; } }
        public double Bonus { get { return _bonus; } }
        public string Name { get { return _name; } }
        public Employee(string name, double salary, double bonus)
        {
            _name = name;
            _salary = salary;
            _bonus = bonus;
        }
        public void CalculatePay()
        {
            double totalPay = Salary + Bonus;
            Console.WriteLine("Total Pay for Employee {0} = {1}", Name, totalPay);
        }
    }
