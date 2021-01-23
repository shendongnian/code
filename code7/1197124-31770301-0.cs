    var myBinding = new Binding
    {
        Source = NotifyFields,
        Path = new PropertyPath("DebugEnabled"),
        Mode = BindingMode.TwoWay,
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
    };
    BindingOperations.SetBinding(tsGeneratedSwitch, CheckBox.IsCheckedProperty, myBinding);
