    public class IDValidator : ValidationRule
    {
        private IDValidatorRange _range;
    
        public int MinLength { get; set; }
    
        public int MaxLength { get; set; }
    
        public IDValidatorRange Range
        {
            get { return _range; }
            set
            {
                _range = value;
                value?.SetValidator(this);
            }
        }
    
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Logic
        }
    }
