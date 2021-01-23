    public string MyProperty
    {
        get { return (string)GetValue(MyPropertyProperty); }
        set
        {
            SetValue(MyPropertyProperty, value);
        }
    }
    
    public static readonly DependencyProperty MyPropertyProperty =
      DependencyProperty.Register("MyProperty", typeof(string), typeof(MyUserControl), new PropertyMetadata(null, OnPropertyChanged));
    
    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if ((string)e.NewValue != (string)e.OldValue)
        {
            Debug.WriteLine(e.NewValue);
        }
    }
