    private ObservableCollection<MyList> list = new ObservableCollection<MyList>();
    
    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    
    private double viewheight;
    
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var scrollViewer = FindChildOfType<ScrollViewer>(gridView);
        scrollViewer.ViewChanged += ScrollViewer_ViewChanged;
        viewheight = gridView.ActualHeight;
    }
    
    private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        var scrollViewer = sender as ScrollViewer;
        var Y = scrollViewer.VerticalOffset;
        //calculate here to get the displayed items.
    }
    
    public static T FindChildOfType<T>(DependencyObject root) where T : class
    {
        var queue = new Queue<DependencyObject>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            DependencyObject current = queue.Dequeue();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
            {
                var child = VisualTreeHelper.GetChild(current, i);
                var typedChild = child as T;
                if (typedChild != null)
                {
                    return typedChild;
                }
                queue.Enqueue(child);
            }
        }
        return null;
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        list.Clear();
        for (int i = 0; i < 200; i++)
        {
            list.Add(new MyList { text = "Item " + i });
        }
    }
