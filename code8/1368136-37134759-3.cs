    private ObservableCollection<MyFlipViewItem> mylist = new ObservableCollection<MyFlipViewItem>();
    
    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        mylist.Clear();
        mylist.Add(new MyFlipViewItem { ImageSource = "Assets/1.jpeg" });
        mylist.Add(new MyFlipViewItem { ImageSource = "Assets/1.jpeg" });
        mylist.Add(new MyFlipViewItem { ImageSource = "Assets/1.jpeg" });
        mylist.Add(new MyFlipViewItem { ImageSource = "Assets/1.jpeg" });
    }
    
    private ScrollViewer flipviewscrollviewer;
    
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        flipviewscrollviewer = FindChildOfType<ScrollViewer>(flipView);
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
    
    private void ScrollViewer_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        var itemscrollviewer = sender as ScrollViewer;
        if (itemscrollviewer.ZoomFactor != 1)
        {
            flipviewscrollviewer.HorizontalScrollMode = ScrollMode.Disabled;
        }
        else
        {
            flipviewscrollviewer.HorizontalScrollMode = ScrollMode.Enabled;
        }
    }
