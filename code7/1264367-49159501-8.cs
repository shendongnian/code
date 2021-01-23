	public class DynamicResourceBindingExtension : MarkupExtension, IValueConverter {
		public DynamicResourceBindingExtension() { }
		public DynamicResourceBindingExtension(object resourceKey)
			=> ResourceKey = resourceKey;
		public object          ResourceKey        { get; set; }
		public IValueConverter Converter          { get; set; }
		public object          ConverterParameter { get; set; }
		public CultureInfo     ConverterCulture   { get; set; }
		public string          StringFormat       { get; set; }
		public object          FallbackValue      { get; set; }
		public object          TargetNullValue    { get; set; }
		private DynamicResourceExtension dynamicResource;
		public override object ProvideValue(IServiceProvider serviceProvider) {
			// Get the expression representing the DynamicResource
			dynamicResource = new DynamicResourceExtension(ResourceKey);
			// Get the TargetInfo for this markup extension
			var targetInfo = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
			// If the TargetObject is a FrameworkElement, it means we're being applied directly,
			// not via a style, so we can go ahead and set up everything here and we're done.
			if(targetInfo.TargetObject is FrameworkElement targetFrameworkElement){
				var dynamicResourceBinding = CreateDynamicResourceBinding(targetFrameworkElement);
				var initialValue = dynamicResourceBinding.ProvideValue(serviceProvider);
				var targetProperty = (DependencyProperty)targetInfo.TargetProperty;
				// Once we exit, replace the target with the actual binding
				SynchronizationContext.Current.Post((o) => {
					targetFrameworkElement.SetBinding(targetProperty, dynamicResourceBinding);
			
				}, null);				
				return initialValue;
			}
			// If TargetObject is a setter, it means we're being used in a style
			if(targetInfo.TargetObject is Setter setter){
				// Ok, we're in a style so we need to get two things:
				//   1. The target FrameworkElement, and...
				//   2. The target property of the setter
				// We can get #2 here, but we won't get #1 until the style is actually applied, so we use a trick
				// where we create a binding with a relativeSource of 'Self' and specify a converter
				// Then in the ConvertValue, we will be handed the FrameworkElement we're being applied to.
				// Using that value, and the TargetProperty which we pass in as a parameter,
				// we can finally set up the binding
				
				var selfBinding = new Binding(){
					RelativeSource     = new RelativeSource(RelativeSourceMode.Self),
					ConverterParameter = setter.Property,
					Converter          = this
				};
				return selfBinding;
			}
			// We weren't applied against a FrameworkElement directly, nor via a style, so just return the DynamicResource as-is
			// (Not sure how we'd ever get here, but still...)
			return dynamicResource;
		}
		public Binding CreateDynamicResourceBinding(FrameworkElement targetFrameworkElement){
			// Get the ResourceReferenceExpression for the dynamic resource
			var resourceReferenceExpression = dynamicResource.ProvideValue(null);
			// Create the Freezable-based object to be used as the source of the binding
			// Use the resourceReferenceExpression for its value
			var bindingSource = new BindingProxy(resourceReferenceExpression);
			// Add the it to the target FrameworkElement's Resources collection (using itself as its key for uniqueness)
			// so it participates in the dynamic resource lookup chain relative to that FrameworkElement
			targetFrameworkElement.Resources.Add(bindingSource, bindingSource);
			// Set up and return a binding using that object as its binding source
			return new Binding() {
				Path               = new PropertyPath(BindingProxy.ValueProperty),
				Source             = bindingSource,
				Converter          = Converter,
				ConverterParameter = ConverterParameter,
				ConverterCulture   = ConverterCulture,
				StringFormat       = StringFormat,
				FallbackValue      = FallbackValue,
				TargetNullValue    = TargetNullValue,
				Mode               = BindingMode.OneWay
			};
		}
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			
			var frameworkElement = (FrameworkElement)value;
			var targetProperty   = (DependencyProperty)parameter;
			// Create the final binding to be used
			var dynamicResourceBinding = CreateDynamicResourceBinding(frameworkElement);
			// We now set the binding.  However, we must post this as it has to happen
			// *after* this conversion returns since we're technically in the middle of
			// the selfBinding's processing
			SynchronizationContext.Current.Post((o) => {
				frameworkElement.SetBinding(targetProperty, dynamicResourceBinding);
			
			}, null);
			// Since we don't actually care what's returned here as the dynamicResourceBinding will
			// be set in a minute, we simply return Binding.DoNothing here.
			return Binding.DoNothing;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}
