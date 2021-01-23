	public class DynamicResourceBindingExtension : MarkupExtension {
		public DynamicResourceBindingExtension(){}
		public DynamicResourceBindingExtension(object resourceKey)
			=> ResourceKey = resourceKey ?? throw new ArgumentNullException(nameof(resourceKey));
		public object          ResourceKey        { get; set; }
		public IValueConverter Converter          { get; set; }
		public object          ConverterParameter { get; set; }
		public CultureInfo     ConverterCulture   { get; set; }
		public string          StringFormat       { get; set; }
		public object          TargetNullValue    { get; set; }
		private BindingProxy bindingSource;
		public override object ProvideValue(IServiceProvider serviceProvider) {
			// Get the binding source for all targets affected by this MarkupExtension
			// whether set directly on an element or object, or when applied via a style
			// Store it in a member variable so the wrapper converter's Convert method can access it.
			var dynamicResource = new DynamicResourceExtension(ResourceKey);
			bindingSource       = new BindingProxy(dynamicResource.ProvideValue(null));
			// Set up the binding using the just-created source
			var dynamicResourceBinding = new Binding() {
				Path               = new PropertyPath(BindingProxy.ValueProperty),
				Source             = bindingSource,
				Converter          = Converter,
				ConverterParameter = ConverterParameter,
				ConverterCulture   = ConverterCulture,
				TargetNullValue    = TargetNullValue,
				Mode               = BindingMode.OneWay
			};
			// Set up a helper binding used to receive the ultimate target of the markup extension
			// (i.e. what it's applied to either directly or via a style) by using 'RelativeSourceMode.self'
			var targetObjectBinding = new Binding(){
				RelativeSource = new RelativeSource(RelativeSourceMode.Self)
			};
			// Create a wrapper multi-binding using the two above bindings
			// Specify a local converter (in which we grab the actual target to configure it)
			// This converter will be called on every change to the DynamicResource, for every object
			// it's been assigned to
			// Note: You must set StringFormat on the wrapper binding, not DynamicResourceBinding
			// as StringFormat is only applied if the target type of the binding is a string, which
			// it won't be for DynamicResourceBinding as its target type is a MultiBinding (this wrapperBinding)
			var wrapperBinding = new MultiBinding(){
				Bindings        = {targetObjectBinding, dynamicResourceBinding},
				Converter       = new InlineMultiConverter(WrapperConvertValue),
				StringFormat    = StringFormat,
				Mode            = BindingMode.OneWay
			};
				
			// Return the result of the wrapper binding's ProvideValue, as if we were the MultiBinding ourselves
			return wrapperBinding.ProvideValue(serviceProvider);
		}
		// This gets called on every change of the dynamic resource, for every object it's been applied to
		// either when applied directly, or via a style
		private object WrapperConvertValue(object[] values, Type targetType, object parameter, CultureInfo culture) {
			var bindingTargetObject          = values[0]; // The object this binding targets
			var dynamicResourceBindingResult = values[1]; // The actual result of the DynamicResourceBinding
			// If the binding target object is a FrameworkElement, ensure the BindingSource is in its Resources collection
			// Note: Set the value by key, don't use add, as this will be called multiple times
			if(bindingTargetObject is FrameworkElement targetFrameworkElement)
				targetFrameworkElement.Resources[bindingSource] = bindingSource;
			// Return (pass thru) the result of the actual DynamicResourceBinding
			return dynamicResourceBindingResult;
		}
	}
