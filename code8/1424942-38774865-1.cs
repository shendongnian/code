    public class CompositeKey
    {
         public CompositeKey(string firstName, string lastName, string zipCode)
         {
               FirstName = firstName;
               LastName = lastName;
               ZipCode = zipCode;
         }
    
         public string FirstName { get; }
         public string LastName { get; }
         public string ZipCode { get; }
    }
