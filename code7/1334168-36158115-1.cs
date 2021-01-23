    public class YourViewModel : IValidatableObject
    {
        public ICollection<IFormFile> Attachments { get;set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var numAttachments = Attachments?.Count() ?? 0;
            if (numAttachments == 0)
            {
                yield return new ValidationResult(
                    "You must attached at least one file.",
                    new string[] { nameof(Attachments) });
            }
        }
    }
