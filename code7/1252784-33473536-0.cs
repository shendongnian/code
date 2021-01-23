    InitializeComponent();
    panelControl.Visibility = Visibility.Hidden;
    BindingOperations.SetBinding(panelControl, Control.VisibilityProperty,
        new Binding()
    {
        Path = new PropertyPath(nameof(ViewModel.MyViewModelProperty_IsVisible_ConvertedToVisibility)),
        Source = viewModelInstance, // this.DataContext ?
    });
