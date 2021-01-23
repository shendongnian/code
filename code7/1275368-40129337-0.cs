    public class Person {
       public string FirstName {get;set}
       public string SecondName {get;set}
       public string Name => $"{FirstName} {SecondName}";
    }
    
