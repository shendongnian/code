	public class ValidateBehavior : Behavior<TextBox>
	{
		public ValidationDelegate Validated
		{
			get { return (ValidationDelegate)GetValue(ValidatedProperty); }
			set { SetValue(ValidatedProperty, value); }
		}
		public static readonly DependencyProperty ValidatedProperty =
			DependencyProperty.Register("Validated", typeof(ValidationDelegate), typeof(ValidateBehavior), new PropertyMetadata(null));
		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.TextChanged += ValidateText;
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.TextChanged -= ValidateText;
		}
		private void ValidateText(object sender, TextChangedEventArgs e)
		{
			if (this.Validated != null)
			{
				bool isValid = true; // do text validation here
				this.Validated(isValid);
			}
		}
	}
