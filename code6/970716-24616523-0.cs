    public class Employee : IEmployee
    {
    
        public string EmployeeName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    
    public ISalary Salary{get; set;}
    }
    
    public class Salary: ISalary
    {
      public int Money{get; set;}
    }
    
    public class BigBucksSalary: ISalary
    {
      public int Money{get; set;}
    }
