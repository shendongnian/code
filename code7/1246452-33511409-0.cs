    public LabelWithRequiredInfo()
    {
        var dpd = DependencyPropertyDescriptor.FromProperty(Label.TargetProperty, typeof(Label));
        dpd.AddValueChanged(this, SearchForRequiredValidationRule);
    }
    private void SearchForRequiredValidationRule(object sender, EventArgs e)
    {
        var textbox = Target as TextBox;
        if (textbox != null)
        {
            Binding binding = BindingOperations.GetBinding(textbox, TextBox.TextProperty);
            var requiredValidationRule = binding.ValidationRules
                                                .OfType<RequiredValidationRule>()
                                                .FirstOrDefault();
            if (requiredValidationRule != null)
            {
                // makes the required legend (red (*) for instance) to appear
                IsRequired = true;
            }
        }
    }
