    // Common properties can be set using a "common builder"
    public class EmployeeBuilder
    {
       public void BuildFromObject (Employee employee)
       {
            emp.DailyWorkHours   = "8hours";
            emp.WeeklyHolidays  = "saturday and Sunday" ;
       } 
    }
    public class ContractEmployeeBuilder
    {
       public void BuildObject ()
       {
            ContractEmployee emp = new ContractEmployee();
            
            // Then you use common builder here
            new EmployeeBuilder().BuildFromObject(employee);
            
            emp.ContractDuration = "1 month" ;
       } 
    }
    
    public class FullTimeEmployeeBuilder
    {
         public void BuildObject()
         {
              FullTimeEmployee emp = new FullTimeEmployee();
              // ... and also here
              new EmployeeBuilder().BuildObject(emp);
    
              emp.MonthlySalary    = "£2500";
         } 
    }
