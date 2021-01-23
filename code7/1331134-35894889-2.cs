    public class TestModel : IValidatableObject {
        public string property1 {get;set;}
        public string property2 {get;set;}
         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
             if (string.IsNullOrWhiteSpace(property1) && string.IsNullOrWhiteSpace(property2)) {
                  yield return new ValidationResult(
                      "some error message", 
                      new[] { "property1", "property2"}
                  );
             }
         }
    }
