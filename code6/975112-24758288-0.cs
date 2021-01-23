    public bool ShowMyGrid
    {
        get { return (bool)GetValue(ShowMyGridProperty); }
        set { SetValue(ShowMyGridProperty, value); }
    }
    
    public static readonly DependencyProperty ShowMyGridProperty =
        DependencyProperty.Register("ShowMyGrid", typeof(bool), typeof(MyUserControl1), new UIPropertyMetadata(false, ShowMyGridCallback));
    
    
    static void ShowMyGridCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var myControl = d as MyUserControl1;
        bool newVal = (bool)e.NewValue;
        if (newVal)
        {
            myControl.MyGrid.Visibility = Visibility.Collapsed;
            myControl.MyOtherGrid.Visibility = Visibility.Visible;
        }
        else
        {
            myControl.MyGrid.Visibility = Visibility.Visible;
            myControl.MyOtherGrid.Visibility = Visibility.Collapsed;
        }
    }
    
