    public class AssetModel:IValidatableObject
    {
        private static List<string> allowedClassNames = new List<string> {"Real Estate", "Factored Debt"};
        [Required]
        public string assetClassName { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!allowedClassNames.Contains(assetClassName)
            {
                yield new ValidationResult("Not an allowed value", new string[] { "assetClassName" } );
            }
        }
    }
