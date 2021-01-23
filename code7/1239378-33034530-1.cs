	public class MyBinding : MarkupExtension
	{
		public string ThePath { get; set; }
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			Binding binding = new Binding(ThePath) {
				Mode = BindingMode.TwoWay,
				NotifyOnValidationError = true,
				UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
				ValidatesOnDataErrors = true
			};
			binding.ValidationRules.Add(new ExceptionValidationRule());
			return binding;
		}
	}
