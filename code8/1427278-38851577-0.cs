    public class CustomCompareAttribute: CompareAttribute {
        public CustomCompareAttribute(string otherProperty) : base(otherProperty) {
        }
       protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
           if (OtherProperty == null && value == null) {
                return new ValidationResult("Either A or B should be filled");
            }
            // more checks here ...
       }
    }
