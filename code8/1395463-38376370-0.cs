    ComboBox Box = new ComboBox();
    Binding b = new Binding()
    {
        Source = YourViewModel, 
        Path = new PropertyPath("YourViewModelProperty"),
        Mode = BindingMode.TwoWay
    };
    Box.SetBinding(ComboBox.SelectedValueProperty, b);
