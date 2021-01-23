    private void off_chek_select(object sender, RoutedEventArgs e)
    {
        var cbSender = sender as CheckBox;
        if (cbSender != null)
        {
            var stackPanel = cbSender.Tag as StackPanel;
            if (stackPanel != null)
            {
                var cb1 = stackPanel.FindName("cb1") as CheckBox;
                if (cb1 != null)
                {
                    cb1.IsChecked = !cbSender.IsChecked;
                }
            }
        }
    }
    
    private void ins_chek_select(object sender, RoutedEventArgs e)
    {
        var cbSender = sender as CheckBox;
        if (cbSender != null)
        {
            var stackPanel = cbSender.Tag as StackPanel;
            if (stackPanel != null)
            {
                var cb = stackPanel.FindName("cb") as CheckBox;
                if (cb != null)
                {
                    cb.IsChecked = !cbSender.IsChecked;
                }
            }
        }
    }
