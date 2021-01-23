    public class MyModel : IValidatableObject
    {
        // Your properties go here
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // You may want to check your properties for null before doing this
            var sumOfFields = PhoneNumber.Length + Area.Length + Prefix.Length;
            if(sumOfFields != 10)
                return new ValidationResult("Incorrect phone number!");
        }
    }
