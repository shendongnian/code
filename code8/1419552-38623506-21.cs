    Binding myBinding = new Binding();
    myBinding.Source = this.DataContext;
    myBinding.Path = new PropertyPath("ChangeDescriptionCommand");
    myBinding.Mode = BindingMode.OneWay;
    myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    BindingOperations.SetBinding(ItemColumn, CustomComboBoxColumn.CommandProperty, myBinding);
