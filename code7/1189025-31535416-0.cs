    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee> 
            {
                new Employee{EmpID = 1},
                new Employee{EmpID = 1},
                new Employee{EmpID = 2},
                new Employee{EmpID = 5},
                new Employee{EmpID = 8},
                new Employee{EmpID = 1},
                new Employee{EmpID = 9},
                new Employee{EmpID = 1},
                new Employee{EmpID = 2}
            };
            List<Manager> mgrList = new List<Manager> 
            {
                new Manager{ManagerID = 7},
                new Manager{ManagerID = 3},
                new Manager{ManagerID = 6}               
            };
            var result = (from emp in empList
                         join mgr in mgrList on emp.EmpID equals mgr.ManagerID
                         select new { emp.EmpID}).Count();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
    public class Employee
    { 
        public int EmpID { get; set; } 
    }
    public class Manager
    { 
        public int ManagerID { get; set; }
    }
