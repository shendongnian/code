    public static readonly DependencyProperty MessagePlayerProperty = DependencyProperty.Register(
            "MessagePlayer", typeof (Player), typeof (VideoMessage), new PropertyMetadata(default(Player), PropertyChangedCallback));
    private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
          //new value is in the e.NewValue
    }
