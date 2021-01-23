    public static readonly DependencyProperty SelectedGelPakProperty =
        DependencyProperty.Register(
            "SelectedGelPak",
            typeof(object),
            typeof(GelPakPickerOverlay),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)); // here
