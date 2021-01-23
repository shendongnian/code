    class Employee
    {
        protected int empID;
        public int EmployeeID 
        {
            get { return empId; }
        }
        //more code here
        public void AskEmployeeID()
        {
            Console.WriteLine("Please enter Employee ID:");
            this.empID = int.Parse(Console.ReadLine());
        }
    }
