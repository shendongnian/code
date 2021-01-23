    [Table("employeeTable")]
    public class Messsaging : IValidatableObject
    {
        public virtual int id { set; get; }
        [Required]
        public virtual String name { set; get; }
        [Required]
        public virtual String country { set; get; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                yield return new ValidationResult("this field can'not be empty", new[] { "name" });
            }
        }
    }
