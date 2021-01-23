    public static readonly DependencyProperty ...StuffProperty =
        DependencyProperty.Register(
            "...Stuff", 
            typeof(ObservableCollection<FrameworkElement>),
            typeof(MyControl),
            // The property needs to be initialized
            new PropertyMetadata(new ObservableCollection<FrameworkElement>())
        );
