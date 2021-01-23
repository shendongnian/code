    private void SetNumericUpDownValue(NumericUpDown control, decimal value)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        var currentValueField = this.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
        if (currentValueField != null)
        {
            currentValueField.SetValue(control, value);
            control.Text = value.ToString();
        }
    }
