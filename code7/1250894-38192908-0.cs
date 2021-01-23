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
                if (DesignValue == null)
                    return null;
                
                var propertyType = property.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    propertyType = propertyType.GetGenericArguments()[0];
                if (!propertyType.IsInstanceOfType(DesignValue))
                {
                    if (propertyType.IsEnum)
                    {
                        return Enum.Parse(propertyType, DesignValue.ToString());
                    }
                    try
                    {
                        return Convert.ChangeType(DesignValue, propertyType);
                    }
                    catch { }
                }
                return DesignValue;
            }
            else
            {
                return Binding.ProvideValue(serviceProvider);
            }
        }
    }
