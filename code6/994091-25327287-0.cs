    public class DigitsRangeRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo info)
        {
            int digits = 0;
            try
            {
                digits = Int32.Parse((string)value);
            }
            catch
            {
                return new ValidationResult(false, 
                    "Please specify a valid number of digits.");
            }
            if (digits < Min || digits > Max)
            {
                return new ValidationResult(false, 
                    String.Format("There must be between {0} and {1}" +
                    " digits for detail numbers.", Min, Max));
            }
            return new ValidationResult(true, null);
        }
    }
