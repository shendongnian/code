    public class Sausage : IValidatableObject
    {
        
        public string Location { get; set; }
        [Required]
        public decimal Lat { get; set; }
        [Required]
        public decimal Lng { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Lat == decimal.Zero || Lng == decimal.Zero)
            {
                yield return new ValidationResult("Please ensure both Lng & Lat is filled in", new[] { "Location" });
            }
        }
    }
