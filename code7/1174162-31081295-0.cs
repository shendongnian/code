    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Mail;
    using System.Web.Mvc;
    
    namespace SWCGPExternal.Attributes
    {
        public class CustomEmailAddressAttribute : ValidationAttribute, IClientValidatable
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                    return false;
    
                try
                {
                    MailAddress m = new MailAddress((string)value);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
    
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                var clientValidationRule = new ModelClientValidationRule()
                {
                    ErrorMessage = this.ErrorMessage,
                    ValidationType = "email"
                };
    
                return new[] { clientValidationRule };
            }
    
        }
    }
