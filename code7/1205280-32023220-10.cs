    public class Person 
    {
       // In case you don't want to display class property with there original names
       // you can annotate the property with DisplayName
       
       [DisplayName("First Name")]
       public string FirstName {get; set;}
       public string Initial {get; set;}
       public string LastName {get; set;}
    }
