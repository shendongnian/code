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
		private BindingProxy   bindingSource;
		private BindingTrigger bindingTrigger;
		public override object ProvideValue(IServiceProvider serviceProvider) {
			// Get the binding source for all targets affected by this MarkupExtension
			// whether set directly on an element or object, or when applied via a style
			var dynamicResource = new DynamicResourceExtension(ResourceKey);
			bindingSource = new BindingProxy(dynamicResource.ProvideValue(null)); // Pass 'null' here
			// Set up the binding using the just-created source
			// Note, we don't yet set the Converter, ConverterParameter, StringFormat
			// or TargetNullValue (More on that below)
			var dynamicResourceBinding = new Binding() {
				Source = bindingSource,
				Path   = new PropertyPath(BindingProxy.ValueProperty),
				Mode   = BindingMode.OneWay
			};
			// Get the TargetInfo for this markup extension
			var targetInfo = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
			// Check if this is a DependencyObject. If so, we can set up everything right here.
			if(targetInfo.TargetObject is DependencyObject dependencyObject){
				// Ok, since we're being applied directly on a DependencyObject, we can
				// go ahead and set all those missing properties on the binding now.
				dynamicResourceBinding.Converter          = Converter;
				dynamicResourceBinding.ConverterParameter = ConverterParameter;
				dynamicResourceBinding.ConverterCulture   = ConverterCulture;
				dynamicResourceBinding.StringFormat       = StringFormat;
				dynamicResourceBinding.TargetNullValue    = TargetNullValue;
				// If the DependencyObject is a FrameworkElement, then we also add the
				// bindingSource to its Resources collection to ensure proper resource lookup
				if (dependencyObject is FrameworkElement targetFrameworkElement)
					targetFrameworkElement.Resources.Add(bindingSource, bindingSource);
				// And now we simply return the same value as if we were a true binding ourselves
				return dynamicResourceBinding.ProvideValue(serviceProvider); 
			}
			// Ok, we're not being set directly on a DependencyObject (most likely we're being set via a style)
			// so we need to get the ultimate target of the binding.
			// We do this by setting up a wrapper MultiBinding, where we add the above binding
			// as well as a second binding which we create using a RelativeResource of 'Self' to get the target,
			// and finally, since we have no way of getting the BindingExpressions (as there will be one wherever
			// the style is applied), we create a third child binding which is a convenience object on which we
			// trigger a change notification, thus refreshing the binding.
			var findTargetBinding = new Binding(){
				RelativeSource = new RelativeSource(RelativeSourceMode.Self)
			};
			bindingTrigger = new BindingTrigger();
			var wrapperBinding = new MultiBinding(){
				Bindings = {
					dynamicResourceBinding,
					findTargetBinding,
					bindingTrigger.Binding
				},
				Converter = new InlineMultiConverter(WrapperConvert)
			};
			return wrapperBinding.ProvideValue(serviceProvider);
		}
		// This gets called on every change of the dynamic resource, for every object it's been applied to
		// either when applied directly, or via a style
		private object WrapperConvert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			var dynamicResourceBindingResult = values[0]; // This is the result of the DynamicResourceBinding**
			var bindingTargetObject          = values[1]; // The ultimate target of the binding
			// We can ignore the bogus third value (in 'values[2]') as that's the dummy result
			// of the BindingTrigger's value which will always be 'null'
			// ** Note: This value has not yet been passed through the converter, nor been coalesced
			// against TargetNullValue, or, if applicable, formatted, both of which we have to do here.
			if (Converter != null)
				// We pass in the TargetType we're handed here as that's the real target. Child bindings
				// would've normally been handed 'object' since their target is the MultiBinding.
				dynamicResourceBindingResult = Converter.Convert(dynamicResourceBindingResult, targetType, ConverterParameter, ConverterCulture);
			// Check the results for null. If so, assign it to TargetNullValue
			// Otherwise, check if the target type is a string, and that there's a StringFormat
			// if so, format the string.
			// Note: You can't simply put those properties on the MultiBinding as it handles things differently
			// than a single binding (i.e. StringFormat is always applied, even when null.
			if (dynamicResourceBindingResult == null)
				dynamicResourceBindingResult = TargetNullValue;
			else if (targetType == typeof(string) && StringFormat != null)
				dynamicResourceBindingResult = String.Format(StringFormat, dynamicResourceBindingResult);
			// If the binding target object is a FrameworkElement, ensure the BindingSource is added
			// to its Resources collection so it will be part of the lookup relative to the FrameworkElement
			if (bindingTargetObject is FrameworkElement targetFrameworkElement
			&& !targetFrameworkElement.Resources.Contains(bindingSource)) {
				// Add the resource to the target object's Resources collection
				targetFrameworkElement.Resources[bindingSource] = bindingSource;
				// Since we just added the source to the visual tree, we have to re-evaluate the value
				// relative to where we are.  However, since there's no way to get a binding expression,
				// to trigger the binding refresh, here's where we use that BindingTrigger created above
				// to trigger a change notification, thus having it refresh the binding with the (possibly)
				// new value.
				// Note: since we're currently in the Convert method from the current operation,
				// we must make the change via a 'Post' call or else we will get results returned
				// out of order and the UI won't refresh properly.
				SynchronizationContext.Current.Post((state) => {
					bindingTrigger.Refresh();
				}, null);
			}
			// Return the now-properly-resolved result of the child binding
			return dynamicResourceBindingResult;
		}
	}
