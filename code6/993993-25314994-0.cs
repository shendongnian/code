    public static readonly DependencyProperty UrlProperty = 
      DependencyProperty.Register(
      "Url",
      typeof(string),
      typeof(SettingsWrapper),
      new PropertyMetadata(OnUrlChanged)
      )
    );
    private static void OnUrlChanged(DependencyObject d,
                                     DependencyPropertyChangedEventArgs e)
    {
        SettingsWrapper instance = (SettingsWrapper)d;
        instance.Settings.Url = e.NewValue.ToString();
    }
