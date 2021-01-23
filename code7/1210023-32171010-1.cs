    public static DependencyProperty SelectedProperty = 
         DependencyProperty.Register( "IsSelected", typeof(Boolean),
         typeof(Spot), new FrameworkPropertyMetadata(false));
     
    public Boolean IsSelected
    {
        get { return (Boolean)GetValue(SelectedProperty); }
        set { SetValue(SelectedProperty, value); }
    }
