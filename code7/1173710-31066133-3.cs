    public class SalaryInfo
    {
        public int Salary {get; set;}
        public int Hra {get; set;}
    }
    public class Employee
    {
        // ...
        public SalaryInfo CalculateSalary(int salary)
        {
            var retval = new SalaryInfo(){      
            Basic = salary * (0.40);
            Hra = salary * (0.40) * (0.50); // *0.2 ...
            return retval;
        }
    
        // ...
    }
