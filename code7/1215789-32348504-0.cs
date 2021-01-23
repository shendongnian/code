    public class NameInfo : IValidatableObject
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<DateTime> StartDate { get; set; }
        [Display(Name = "Already Starting")]
        public bool IsStarting { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required!");
            }
            if (!IsStarting && !StartDate.HasValue)
            {
                yield return new ValidationResult("Required.", new[] { "StartDate" });
            }
        }
    }
