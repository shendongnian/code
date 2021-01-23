    using System.Globalization;
    using System.Windows.Controls;
    
    namespace WpfApplication2
    {
        public class RequiredValidate : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                return value != null ? ValidationResult.ValidResult : new ValidationResult(false, "Value required");
            }
        }
    }
