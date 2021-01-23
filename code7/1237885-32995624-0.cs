    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.ComponentModel.DataAnnotations;    
    
    namespace MyProject.Models.Validation
    {
        
        public class StringRangeAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                               
                if(value.ToString() == "M" || value.ToString() == "F")
                {
                    return ValidationResult.Success;
                }
            
    
                return new ValidationResult("Please enter a correct value");
            }
        }
    }
    
