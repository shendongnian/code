    public static readonly DependencyProperty XBackgroundProperty 
                = DependencyProperty.Register("XBackground", typeof(Brush), typeof(YourCustomUserControl));
    public Brush XBackground
    {
        get { return (Brush) GetValue( XBackgroundProperty ); }
        set { SetValue( XBackgroundProperty, value ); }
    }
