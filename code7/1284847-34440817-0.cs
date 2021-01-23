    [DataContract()]
    public class MyMethodQuery: IValidatableObject
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        [StringLength(500, MinimumLength = 5)]
        public string Id { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
             if (Id.Length < 1)
             {
                 yield return new ValidationResult("error");
             }
        }
    }
