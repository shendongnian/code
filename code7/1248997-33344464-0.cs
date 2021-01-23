    using System.ComponentModel.DataAnnotations;
    public class ValidDates : ValidationAttribute
    {
        protected override ValidationResult 
                IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.Employee)validationContext.ObjectInstance;
            DateTime _validFrom = Convert.ToDateTime(model.validFrom);
            DateTime _validTo = Convert.ToDateTime(model.ValidTo);  
            if(validation condition is true)                
                   return ValidationResult.Success;             
             else
                 return ValidationResult.failure;                       
            
        }
    }
