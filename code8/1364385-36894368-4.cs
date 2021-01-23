    public class Encaissement : IValidatableObject
    {
        // A required attribute, validates that this value was submitted    
        [Required(ErrorMessage = "The Encaissment ID must be submitted")]
        public int EncaissementID { get; set; }
    
        public DateTime? DateEncaissement { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
    
            // Validate the DateEncaissment
            if (!this.DateEncaissement.HasValue)
            {
                results.Add(new ValidationResult("The DateEncaissement must be set", new string[] { "DateEncaissement" });
            }
    
           return results;
        }
    }
