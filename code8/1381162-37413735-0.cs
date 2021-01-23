    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(
            "SelectedItem",
            typeof(object),
            typeof(ListViewEx),
            new FrameworkPropertyMetadata(
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
