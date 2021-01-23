    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _source = sender as Border;
        Mouse.Capture(_source);
    }
    private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _source = null;
        Mouse.Capture(null);
    }
