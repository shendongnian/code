    private void dg_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        var u = e.OriginalSource as UIElement;
        if (e.Key == Key.Enter && u != null)
        {
            e.Handled = true;
            u.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
        }
    }
