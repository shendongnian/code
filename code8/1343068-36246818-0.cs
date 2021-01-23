            public class AtleastOneAttribute : ValidationAttribute//, IClientValidatable
                {
                    // For Server side 
                    public override bool IsValid(object value)
                    {
                        if (value != null && value != string.Empty)
                        {
                            return true;
                        }
                        return false;
                    }
                    // Implement IClientValidatable for client side Validation
                    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
                    {
                        return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "atleastonetrue", ErrorMessage = this.ErrorMessage } };
                    }
                }
            
     
    
       //For client-side validation to work, you need to include the following script in your view (or in a javascript file that you reference)
            jQuery.validator.unobtrusive.adapters.add("atleastonetrue", function (options) {
                if (options.element.tagName.toUpperCase() == "INPUT" && options.element.type.toUpperCase() == "HIDDEN") {
                    options.rules["required"] = true;
                    if (options.message) {
                        options.messages["required"] = options.message;
                    }
                }
            });
