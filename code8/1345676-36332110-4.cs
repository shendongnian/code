    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
        public class ValidateCollectionAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var collection = value as IEnumerable;
    
                if (collection != null)
                {
                    foreach (object element in collection)
                    {
                        //do validation
                    }
                }
    
                return ValidationResult.Success;
            }
        }
