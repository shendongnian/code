    public static readonly DependencyProperty TextBoxTextProperty = 
        DependencyProperty.Register
        (
            "TextBoxText", 
            typeof(string), 
            typeof(SpecialUserControl),
            new PropertyMetadata("")
        );
    
    public string TextBoxText
    {
        get { return this.GetValue(TextBoxTextProperty) as string; }
        set { this.SetValue(TextBoxTextProperty, value); }
    }
    
    public static readonly DependencyProperty LabelTextProperty = 
        DependencyProperty.Register
        (
            "LabelText", 
            typeof(string), 
            typeof(SpecialUserControl),
            new PropertyMetadata("")
        );
    
    public string LabelText
    {
        get { return this.GetValue(LabelTextProperty) as string; }
        set { this.SetValue(LabelTextProperty, value); }
    }
