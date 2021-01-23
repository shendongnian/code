    this.Loaded += (s, e) =>
        {
            var controls = this.sourceGrid.Children.OfType<Control>();
            controls.ToList().ForEach(c =>
            {
                ComboBox combo = c as ComboBox;
                Binding newBinding = null;
                if (combo != null)
                {
                    newBinding = BindingOperations.GetBinding(combo, ComboBox.IsEnabledProperty);
                }
                c.IsEnabled = false;
                if (combo != null)
                {
                    BindingOperations.SetBinding(combo, ComboBox.IsEnabledProperty, newBinding);
                }
            });
            controls.ToList().ForEach(c =>
            {
                ComboBox combo = c as ComboBox;
                Binding newBinding = null;
                if (combo != null)
                {
                    newBinding = BindingOperations.GetBinding(combo, ComboBox.IsEnabledProperty);
                }
                c.IsEnabled = true;
                if (combo != null)
                {
                    BindingOperations.SetBinding(combo, ComboBox.IsEnabledProperty, newBinding);
                }
            });
        };
