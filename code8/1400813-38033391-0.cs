    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { EmployeeName = "Nancy", EmployeeId = 1, BossId = 2 });
            employees.Add(new Employee() { EmployeeName = "Andrew", EmployeeId = 2, BossId = 0 });
            employees.Add(new Employee() { EmployeeName = "Janet", EmployeeId = 1, BossId = 2 });
            var employeesWithBossName = employees.Join(employees,
                 emp1 => emp1.BossId,
                 emp2 => emp2.EmployeeId,
                 (emp1, emp2) => new { EmployeeName = emp1.EmployeeName, BossName = emp2.EmployeeName });
            
            foreach (var item in employeesWithBossName)
            {
                Console.WriteLine("{0} {1}", item.EmployeeName, item.BossName);
            }
            Console.Read();
        }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int BossId { get; set; }
    }
