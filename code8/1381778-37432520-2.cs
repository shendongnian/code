    public class FormVM : IValidatableObject
    {
        [Display(Name = "One")]
        public bool Property1 {get;set;}
        [Display(Name = "Two")]
        public bool Property2 {get;set;}
        [Display(Name = "Three")]
        public bool Property3 {get;set;}
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (!(Property1 || Property2 || Property3))
            {
                results.Add(new ValidationResult("You must select at least one property."));
            }
            return results;
        }
    }
