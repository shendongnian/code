	public class StaticResourceBinding : StaticResourceExtension
	{
		public StaticResourceBinding(){}
		public StaticResourceBinding(string resourceKey)
		: base(resourceKey){}
		public IValueConverter Converter          { get; set; }
		public object          ConverterParameter { get; set; }
		public CultureInfo     ConverterCulture   { get; set; }
		public string          StringFormat       { get; set; }
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var staticResourceValue = base.ProvideValue(serviceProvider);
			if(Converter == null)
				return (StringFormat != null)
					? string.Format(StringFormat, staticResourceValue)
					: staticResourceValue;
			var targetInfo               = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
			var targetFrameworkElement   = (FrameworkElement)targetInfo.TargetObject;
			var targetDependencyProperty = (DependencyProperty)targetInfo.TargetProperty;
			var convertedValue = Converter.Convert(staticResourceValue, targetDependencyProperty.PropertyType, ConverterParameter, ConverterCulture);
			return (StringFormat != null)
				? string.Format(StringFormat, convertedValue)
				: convertedValue;
		}
	}
