    public ObservableCollection<MyImage> MyImages;
    
    public MainPage()
    {
        this.InitializeComponent();
        MyImages = new ObservableCollection<MyImage>();
        MyImages.Add(new MyImage("ms-appx:///Assets/cliff.jpg"));
        MyImages.Add(new MyImage("ms-appx:///Assets/grapes.jpg"));
        MyImages.Add(new MyImage("ms-appx:///Assets/rainer.jpg"));
        MyImages.Add(new MyImage("ms-appx:///Assets/sunset.jpg"));
        MyImages.Add(new MyImage("ms-appx:///Assets/valley.jpg"));
        MyFlipView.ItemsSource = MyImages;
    }
    
    private async void scrollViewer_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
    {
        var scrollViewer = sender as ScrollViewer;
        var doubleTapPoint = e.GetPosition(scrollViewer);
    
        if (scrollViewer.ZoomFactor != 1)
        {
            scrollViewer.ZoomToFactor(1);
        }
        else if (scrollViewer.ZoomFactor == 1)
        {
            scrollViewer.ZoomToFactor(2);
    
            var dispatcher = Window.Current.CoreWindow.Dispatcher;
            await dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
          {
              scrollViewer.ScrollToHorizontalOffset(doubleTapPoint.X);
              scrollViewer.ScrollToVerticalOffset(doubleTapPoint.Y);
          });
        }
    }
