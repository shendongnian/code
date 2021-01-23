    public class CustomerEntity() : IValidatableObject
    {
        public string Name {get;set;}
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Possibly check for null here as well...
            if (this.Name.ToUpper() != this.Name)
            {
                yield return new ValidationResult("You need to save as upper!"); 
            }
        }
    }
