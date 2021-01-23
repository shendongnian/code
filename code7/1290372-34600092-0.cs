         <DatePicker Width="100" Height="30"  >
            <DatePicker.SelectedDate>
                <Binding Path="DepartureDate" Mode="OneWayToSource" UpdateSourceTrigger="PropertyChanged">
                    <Binding.ValidationRules>
                        <local:MyValidationRule/>
                    </Binding.ValidationRules>
                </Binding>
            </DatePicker.SelectedDate>
        </DatePicker>
    public class MyValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                return new ValidationResult(false, "ErrorContent");
            }
        }
    public class MyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(false, "ErrorContent");
        }
    }
