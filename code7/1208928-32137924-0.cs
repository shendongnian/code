    public bool IsToday
    {
        get { return (bool)GetValue(IsTodayProperty); }
        set { SetValue(IsTodayProperty, value); }
    }
    public static readonly DependencyProperty IsTodayProperty =
        DependencyProperty.Register("IsToday", typeof(bool), typeof(EventListTemplate), new PropertyMetadata(false, OnIsTodayChanged));
    static void OnIsTodayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var template = (EventListTemplate)d;
        if ((bool)e.NewValue)
        {
            var stateset = VisualStateManager.GoToState(template, "DayItemToday", false);
            Debug.WriteLine("did it:", stateset);
        }
    }
