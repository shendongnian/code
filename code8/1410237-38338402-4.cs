    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    namespace ValidationRules
    {
        public class PositiveIntegerRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                int result;
                if (value.GetType() == typeof(String) && Int32.TryParse((String)value, out result) && result > 0)
                    return new ValidationResult(true, null);
                return new ValidationResult(false, "Value must be a positive integer");
            }
        }
    }
