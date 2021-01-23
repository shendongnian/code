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
                try
                {
                    var intvalue = System.Convert.ToInt32(value);
                    if (intvalue >= 0)
                        return new ValidationResult(true, null);
                }
                catch
                {
                }
                return new ValidationResult(false, "Value must be a positive integer");
            }
        }
    }
