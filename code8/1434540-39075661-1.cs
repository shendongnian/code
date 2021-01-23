    public class Employee{
    
     public int Id {get;set;}
     public string Firstname {get;set;}
     
     public Employee(string name)
     {
       this.Firstname = name;
     }
    
    }
    
    public class Person
    {
       Employee emp = new Employee("Foo");
       string s = emp.Firstname;
    }
