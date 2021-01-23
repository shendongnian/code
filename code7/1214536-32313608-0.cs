    public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register(
        "HeaderText", typeof(string), typeof(MyCtrl), new PropertyMetaData(OnHeaderTextChanged));
    
    public string HeaderText
    {
        get { return (string)GetValue(HeaderTextProperty); }
        set { SetValue(HeaderTextProperty, value); }
    }
    
    private static void OnHeaderTextChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var ctrl = d as MyCtrl;
        ctrl.txtHeader.Text = (string)e.NewValue;
    }
