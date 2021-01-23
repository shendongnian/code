    public class Employee{
    
     public int Id {get;set;}
     public string Firstname {get;set;}
    
    }
    
    public class Person
    {
       Employee emp = new Employee();
       string s = emp.Firstname;
    }
