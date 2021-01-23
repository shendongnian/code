    public class IndexViewModel : IValidatableObject
    {
        public HttpPostedFileBase ProfilePic { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProfilePic.ContentType != "image/png" && ProfilePic.ContentType != "image/jpeg")
            {
                yield return new ValidationResult("Application only supports PNG or JPEG image types");
            }
            if (ProfilePic.ContentLength > 1000000)
            {
                yield return new ValidationResult("File size must not exceed 1MB");
            }
        }
    }
