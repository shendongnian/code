    public class NoStringInListBiggerThanAttribute : ValidationAttribute
    {
        private readonly int length;
        public NoStringInListBiggerThanAttribute(int length)
        {
            this.length = length;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var strings = value as IEnumerable<string>;
            if(strings == null)
                return ValidationResult.Success;
            var invalid = strings.Where(s => s.Length > length).ToArray();
            if(invalid.Length > 0)
                return new ValidationResult("The following strings exceed the value: " + string.Join(", ", invalid));
            return ValidationResult.Success;
        }
    }
