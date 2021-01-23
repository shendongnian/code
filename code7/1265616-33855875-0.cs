    public class Person
    {
     public string Name {get;set;}    
     public string Address{get;set;}
     public int Age {get;set;}
     public Header {get;set;}
    }    
    public class Header
    {
     public Detail[] Details {get;set;}
    }
    public class Detail
    {
     public string Sub1 {get;set;}
     public string Sub2 {get;set;}
    }
