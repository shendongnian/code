    void contentControl_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        Dispatcher.InvokeAsync(() =>
        {
            contentControl.Foreground = Brushes.Green;
        });
    }
