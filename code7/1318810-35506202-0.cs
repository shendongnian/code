    public class SearchViewModel : IValidatableObject {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        // other properties ...
         // will be called automatically to check ModelState.IsValid
         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
             if (StartDate > EndDate) {
                 yield return new ValidationResult("EndDate must be greater than StartDate", "EndDate");
             }
             // other checks here, also yield ValidationResult ...
         }
    }
