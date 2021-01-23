    var X1Binding = new Binding("Canvas.Left") { ElementName="Ming"};
    X1Binding.Source = ViewModel;
    X1Binding.Mode = BindingMode.TwoWay;
    X1Binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    BindingOperations.SetBinding(lblSelectedItem, ContentProperty, X1Binding);
