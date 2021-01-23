    public string[] Items { get; } =
        {
            "One", "Two", "Three",
        };
    public MainPage()
    {
        InitializeComponent();
    }
    private void ButtonTestClick(object sender, RoutedEventArgs e)
    {
        UIElement clickedElement = sender as UIElement;
        StackPanel stackPanel = FindParent<StackPanel>(clickedElement);
        object value = null;
        stackPanel?.Resources.TryGetValue("TestStoryboard", out value);
        Storyboard storyboard = value as Storyboard;
        storyboard?.Begin();
    }
    public static T FindParent<T>(DependencyObject element)
        where T : DependencyObject
    {
        while (element != null)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            T candidate = parent as T;
            if (candidate != null)
            {
                return candidate;
            }
            element = parent;
        }
        return default(T);
    }
