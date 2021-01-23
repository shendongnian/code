    [AttributeUsage(AttributeTargets.Property)]
    public class MandatoryAttribute:System.Attribute
    {
    }
    public class Employee
    {
      [Mandatory]
      public string EmployeeName{get;set;}
      [Mandatory]	
      public string EmployeeCity{get;set;}
    
      public string EmployeeAccount{get;set;}
    }
