    public class DesignBindingExtension : MarkupExtension
    {
        public object DesignValue { get; set; } = DependencyProperty.UnsetValue;
        [ConstructorArgument("binding")]
        public Binding Binding { get; set; }
        public DesignBindingExtension(Binding binding)
        {
            Binding = binding;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var target = provideValueTarget.TargetObject as FrameworkElement;
            if (DesignerProperties.GetIsInDesignMode(target) && DesignValue != DependencyProperty.UnsetValue)
            {
                var property = provideValueTarget.TargetProperty as DependencyProperty;
                if (property.PropertyType.IsInstanceOfType(DesignValue))
                    return DesignValue;
                return TypeDescriptor.GetConverter(property.PropertyType).ConvertFrom(DesignValue);
            }
            else
            {
                return Binding.ProvideValue(serviceProvider);
            }
        }
    }
