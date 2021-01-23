    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.Property == Window.WindowStateProperty)
        {
            var oldState = (WindowState)e.OldValue;
            var newState = (WindowState)e.NewValue;
            Debug.WriteLine("{0} -> {1}", oldState, newState);
        }
    }
