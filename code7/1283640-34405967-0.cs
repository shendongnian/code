    public class Employee
    {
         public int Id { get; set;}
        
         [ForceSpecialHandling]
         public string Name { get; set; }
    }
    public class CustomSerializer
    {
         public T Serialize<T>(string data)
         {
                 // Write the serialization code here.
         }
    }
    
    // This can be whatever attribute name you want. 
    // You can then check if the property or class has this attribute using reflection.
    public class ForceSpecialHandlingAttribute : Attribute
    {
    }
