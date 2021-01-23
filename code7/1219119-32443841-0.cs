        public class Employee
        {
            public string EmployeeNumber { get; set; }
            
            public string EmployeeName { get; set; }
            public string DOJ { get; set; }
            public string Designation { get; set; }
            public double Salary { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var employeeList = new List<Employee>();
            employeeList.Add(new Employee() 
            {
                EmployeeNumber = "1234GG",
                Designation = "Whatever",
                EmployeeName = "Kerry Kittles",
                Salary = 12232.32d 
            });
            employeeList.Add(new Employee()
            {
                EmployeeNumber = "8676FDD",
                Designation = "Don't Know",
                EmployeeName = "Michael Jordan",
                Salary = 1565766.32d
            });
         }
