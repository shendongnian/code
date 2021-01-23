    public ProgressRing()
    {
        this.DefaultStyleKey = typeof(ProgressRing);
        this.Loaded += ProgressRing_Loaded;
    }
    
    private void ProgressRing_Loaded(object sender, RoutedEventArgs e)
    {
        StoryboardPlay();
    }
    
    public void StoryboardPlay()
    {
        var rootGrid = this.GetTemplateChild("RootGrid") as Grid;
        var std = rootGrid.Resources["std"] as Storyboard;
        std.Begin();
    }
