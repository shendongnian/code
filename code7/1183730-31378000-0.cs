    public static readonly DependencyProperty TobaccoTypeProperty = 
        DependencyProperty.Register(
        "TobaccoType", typeof(String),
        typeof(TimerButton), null
    );
    public String TobaccoType
    {
       get { return (String)GetValue(TobaccoTypeProperty); }
       set { SetValue(TobaccoTypeProperty, value); }
    }
