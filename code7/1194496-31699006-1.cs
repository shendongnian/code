    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem",
            typeof(YourType),
            typeof(YourViewModel),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnSelectedItemChanged)
            )
        );
        public YourType SelectedItem
        {
            get { return (YourType)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
