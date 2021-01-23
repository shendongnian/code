    public class Employee
    {
       public string YouProperty { get; set; }
    }
    
    var employee = new Employee();
    
    var result = employee.GetType().GetProperty("YouProperty");
    
    // The result is property info
   
  
