    public class ValidationModel : IValidatableObject {
        // properties as defined above
         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
             if (!string.IsNullOrWhiteSpace(Barcode) && string.IsNullOrWhiteSpace(BarcodeType)) {
                 yield new ValidationResult("BarcodeType is required if Barcode is given", new[] { "BarcodeType" });
             }
         }
    }
