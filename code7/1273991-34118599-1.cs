    public static readonly DependencyProperty MessagePlayerProperty = DependencyProperty.Register(
            "MessagePlayer", typeof (Player), typeof (VideoMessage), new PropertyMetadata(default(Player), PropertyChangedCallback));
    private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
           var control = d as VideoMessage;
           (e.NewValue as Player).Sub(control);
    }
