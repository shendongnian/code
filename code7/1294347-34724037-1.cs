    Binding myBinding = new Binding();
    myBinding.Source = ViewModel.getInstance().User;
    myBinding.Path = new PropertyPath("Metadata[SomeDictonaryKey]");
    myBinding.Mode = BindingMode.TwoWay;
    myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    BindingOperations.SetBinding(tb1, TextBox.TextProperty, myBinding));
