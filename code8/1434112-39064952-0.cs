    public static readonly DependencyProperty StrProperty 
        = DependencyProperty.Register("Str", typeof(string), typeof(MainWindow), 
            new FrameworkPropertyMetadata(FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public string Str
    {
        get{return (string)GetValue(StrProperty);}
        set{SetValue(StrProperty,value);}
    }
