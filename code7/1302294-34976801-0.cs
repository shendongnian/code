    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(int), typeof(ImageList), new PropertyMetadata(0, new PropertyChangedCallback(MyControl.MyAppBar.OnUserControlTextPropertyChanged)));
    public string Message
    {
        get { return (string)GetValue(MessageProperty); }
        set { SetValue(MessageProperty, value); }
    }
