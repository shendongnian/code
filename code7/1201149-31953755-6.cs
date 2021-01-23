	public static class ValidateBehavior
	{
		public static ValidationDelegate GetValidate(TextBox textbox)
		{
			return (ValidationDelegate)textbox.GetValue(ValidateProperty);
		}
		public static void SetValidate(TextBox textbox, ValidationDelegate value)
		{
			textbox.SetValue(ValidateProperty, value);
		}
		public static readonly DependencyProperty ValidateProperty =
			DependencyProperty.RegisterAttached(
			"Validate",
			typeof(ValidationDelegate),
			typeof(ValidateBehavior),
			new UIPropertyMetadata(null, OnValidateChanged));
		static void OnValidateChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
		{
			var textbox = depObj as TextBox;
			if (textbox == null)
				return;
			if (e.OldValue is ValidationDelegate)
				textbox.TextChanged -= OnTextChanged;
			if (e.NewValue is ValidationDelegate)
				textbox.TextChanged += OnTextChanged;
		}
		static void OnTextChanged(object sender, RoutedEventArgs e)
		{
			if (!Object.ReferenceEquals(sender, e.OriginalSource))
				return;
			var textbox = e.OriginalSource as TextBox;
			if (textbox != null)
			{
				var validate = GetValidate(textbox);
				if (validate != null)
				{
					bool isValid = true; // do text validation here
					validate(isValid);
				}
			}
		}
	}
