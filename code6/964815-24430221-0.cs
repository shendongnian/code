    public static readonly DependencyProperty SelectedItemProperty =
    DependencyProperty.Register(
         "SelectedItem",
         typeof(object),
         typeof(**ViewNavigatorControl**),
         new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
