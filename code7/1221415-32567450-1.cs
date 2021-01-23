    //  The type argument to BindingTarget is the type of the property. 
    _selectedValueBindingTarget = new BindingTarget<Object>();
    _selectedValueBindingTarget.ValueChanged += (s, e2) =>
    {
        SelectedValue = e2.NewValue;
    };
    Binding binding = new Binding("SelectedItem." + SelectedValuePath);
    binding.Mode = BindingMode.OneWay;
    binding.Source = this;
    BindingOperations.SetBinding(_selectedValueBindingTarget, 
        BindingTarget<Object>.ValueProperty, binding);
