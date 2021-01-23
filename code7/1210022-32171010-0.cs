    // Dependency Property
    public static DependencyProperty CurrentTimeProperty = 
         DependencyProperty.Register( "CurrentTime", typeof(DateTime),
         typeof(MyClockControl), new FrameworkPropertyMetadata(DateTime.Now));
     
    // .NET Property wrapper
    public DateTime CurrentTime
    {
        get { return (DateTime)GetValue(CurrentTimeProperty); }
        set { SetValue(CurrentTimeProperty, value); }
    }
