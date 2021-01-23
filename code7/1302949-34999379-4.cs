    public class MyApiModel(){
       public string Name {get;set;}
    
       public int SomethingElse {get;set;}
       //Computed property in our view model
       //Lets say anything greater than 2 is valid
       public bool IsValid => SomethingElse > 2;
    }
