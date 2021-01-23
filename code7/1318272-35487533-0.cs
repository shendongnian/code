    void RemoveElementFromItsParent(FrameworkElement el)
    {
        if (el.Parent == null)
            return;
    
        var panel = el.Parent as Panel;
        if (panel != null)
        {
            panel?.Children.Remove(el);
            return;
        }
    
        var contentControl = el.Parent as ContentControl;
        if (contentControl != null)
            contentControl.Content = null;
    }
