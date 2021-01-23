    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        base.OnPreviewKeyDown(e);
    
        if (e.Key == Key.Back || e.Key == Key.Delete)
        {
            if (SelectionLength == Text.Length ||
               (Text.Length == 1 && (SelectionStart == 0 && e.Key == Key.Delete || SelectionStart == 1 && e.Key == Key.Back)))
                Text = null;
                RaiseEvent(new RoutedEventArgs(TextChangedEvent));
        }
    }
