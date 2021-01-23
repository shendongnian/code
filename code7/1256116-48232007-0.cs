    private static void BindingPathPropertyChanged(DependencyObject obj,
        DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is string propertyPath)
        {
            var binding = new Binding
            {  
                Path = new PropertyPath($"Content.{propertyPath}"),
                Mode = BindingMode.OneWay,
                RelativeSource = new RelativeSource
                {
                    Mode = RelativeSourceMode.Self
                }
            };
            BindingOperations.SetBinding(obj, Control.IsTabStopProperty, binding);
        }
    }
