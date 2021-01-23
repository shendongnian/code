    /// <summary>
    /// Save Log command
    /// </summary>
    public static readonly RoutedCommand SaveLog =
        new RoutedCommand("SaveLog", typeof(Commands),
            new InputGestureCollection 
            {
                new KeyGesture(Key.S, ModifierKeys.Control,"Save log contents to a file. (Ctl+S)")
            });
