    var X1Binding = new Binding("Canvas.Left") { ElementName="Ming"};
    //X1Binding.Source = ViewModel; // Well the canvas is not on the view model so default value is the datacontext of the view.
    X1Binding.Mode = BindingMode.TwoWay;
    X1Binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    BindingOperations.SetBinding(lblSelectedItem, ContentProperty, X1Binding);
