    public class IgnorableValidationRule : ValidationRule
    {
        public bool Ignore { get; set; } = false;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Ignore) return new ValidationResult(true, null);
            return new ValidationResult(false, "Why does everyone ignore me?");
        }
    }
    <TextBox.Text>
        <Binding Path="Data">
            <Binding.ValidationRules>
                <local:IgnorableValidationRule Ignore="True"/> <!-- na na -->
            </Binding.ValidationRules>
        </Binding>
    </TextBox.Text>
