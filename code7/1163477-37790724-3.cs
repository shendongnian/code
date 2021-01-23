    public MainWindow()
    {
        InitializeComponent();
        DependencyPropertyDescriptor
            .FromProperty(ListView.ItemsSourceProperty, typeof(ListView))
            .AddValueChanged(_listView, (s, e) => {
                UpdateWidths();
        });
    }
