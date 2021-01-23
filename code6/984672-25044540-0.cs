    public interface IEmployee
    {
    
      Enums.EmployeeStatusEnum EmpStatus {get;set;}
    }
    public enum EmployeeStatusEnum 
    {
        Unknown = 0,
        Hired= 1,
        Fired= 3
    }
