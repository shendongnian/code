       public class MyClass : IValidatableObject
        {
            [Required(ErrorMessage="Please enter a Start Date")]  
            public DateTime? StartDate { get; set; }
    
            [Required(ErrorMessage="Please enter an End Date")]
            public DateTime? EndDate { get; set; }
    
            public IEnumerable<ValidationResult> Validate(ValidationContext context)
            {
                if (EndDate < StartDate)
                {
                    yield return new ValidationResult("Invalid date range: End date must be greater then the Start Date");
                }
            }
    }
