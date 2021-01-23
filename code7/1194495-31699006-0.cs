    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem",
            typeof(YourType),
            typeof(YourViewModel),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnSelectedItemChanged)
            )
        );
