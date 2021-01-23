    private void calendar_GotMouseCapture(object sender, MouseEventArgs e)
    {
        UIElement originalElement = e.OriginalSource as UIElement;
        if (originalElement != null)
        {
            originalElement.ReleaseMouseCapture();
        }
    }
