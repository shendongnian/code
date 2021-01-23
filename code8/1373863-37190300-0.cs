    using System.ComponentModel.DataAnnotations;
    
    public class MyObject
    {
       [StringLength(5)]
       public String CompanyName { get; set; }
    }
    
    public void Save(MyObject myObject)
    {
       List<ValidationResult> results = new List<ValidationResult>();
       ValidationContext context = new ValidationContext(myObject, null, null);
       bool isValid = Validator.TryValidateObject(myObject, context, results);
    
       if (!isValid)
       {
          foreach (ValidationResult result in results)
          {
             // Do something
          }
       }
    }
