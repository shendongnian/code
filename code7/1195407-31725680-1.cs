    class Employee
    {
        public int ID;
        public string Name;
        public string Gender;
        public string City;
        public virtual void Detail() // add virtual keyword here to allow overrides.
        {
            Console.WriteLine("Name: {0} \nGender: {1} \nCity: {2} \nID: {3}", Name, Gender, City, ID); //I want to get Yearly or Hourly Salary with these all
        }
    }
    class PermanatEmp : Employee
    {
        public float YearlySalary;
        public override void Detail()
        {
            base.Detail(); // prints base class fields.
            Console.WriteLine("Yearly Salary: {0}", YearlySalary);
        }
    }
    class TempEmp : Employee
    {
        public float HourlySalary;
        
        public override void Detail()
        {
            base.Detail(); // prints base class fields.
            Console.WriteLine("Hourly Salary: {0}", HourlySalary);
        }
    }
