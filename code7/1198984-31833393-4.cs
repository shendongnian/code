    protected override void OnAttached()
    {
        var textBox = (TextBox)this.AssociatedObject;
        textBox.KeyDown += this.OnKeyDown;
        textBox.KeyUp += this.OnKeyUp;
        // don't forget to unsubscribe in OnDetached
    }
    private void OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Tab && !e.Handled)
        {
            e.Handled = this.Work(sender, e);
        }
    }
    
    private void OnKeyUp(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key != VirtualKey.Tab && !e.Handled)
        {
            e.Handled = this.Work(sender, e);
        }
    }
