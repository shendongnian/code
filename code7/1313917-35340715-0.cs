    public class Attachment : IValidatableObject
    {
        //...
    
        public Image Image { get; set; }
        public Font Font { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        { 
            if (Image == null && Font == null) 
            { 
                yield return new ValidationResult 
                 ("Image or Font must be specified", new[] { "Image", "Font" }); 
            }
            if (Image != null && Font != null) 
            { 
                yield return new ValidationResult 
                 ("You cannot provide both an Image and a Font", new[] { "Image", "Font" }); 
            }
        }
    }
