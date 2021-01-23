    public static readonly DependencyProperty OrderProperty =
        DependencyProperty.Register(
            "Order", typeof(string), typeof(NewMazeGrid),
            new PropertyMetadata(OnOrderChanged));
    public string Order
    {
        get { return (string)GetValue(OrderProperty); }
        set { SetValue(OrderProperty, value); }
    }         
  
    private static void OnOrderChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e) 
    {
        ((NewMazeGrid)obj).myMaze.setPresentation((string)e.NewValue);
    }
