    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var leaf = (DependencyObject)sender;
        while(leaf.GetType() != typeof(Frame))
        {
            leaf = VisualTreeHelper.GetParent(leaf);
        }
        Frame f = leaf as Frame;
        if (f != null)
        {
            JournalEntry firstItem = null;
            foreach (JournalEntry item in f.BackStack)
            {
                firstItem = item;
                break;
            }
            this.NavigationService.Navigate(firstItem.Source);
        }
    }
