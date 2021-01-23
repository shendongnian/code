    public static readonly DependencyProperty StatusTextProperty = 
    DependencyProperty.Register("StatusText", typeof(string), typeof(Window1));
    
    public string StatusText
    {
        get
        {
            return this.GetValue(StatusTextProperty) as string;
        }
        set
        {
            this.SetValue(StatusTextProperty, value);
        }
    }
