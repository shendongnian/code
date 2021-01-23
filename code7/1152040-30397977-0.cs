    public class User
    {
    public int UserId {get;set;}
    public string UserName {get;set;}
    
    public PersonDTO Person {get;set;}
    }
    public class Person
    {
    public int PersonID {get;set;}
    public string Name {get;set;}
    
    public Address Address {get;set;}
    public Car Car {get; set;}
    
    }
