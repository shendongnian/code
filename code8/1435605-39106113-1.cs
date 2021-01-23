    private void listBox_MouseMove(object sender, MouseEventArgs e)
    {
        var item = VisualTreeHelper.HitTest(listBox, Mouse.GetPosition(listBox)).VisualHit;
    
        // find ListViewItem (or null)
        while (item != null && !(item is ListBoxItem))
            item = VisualTreeHelper.GetParent(item);
    
        if (item != null)
        {
            int i = listBox.Items.IndexOf(((ListBoxItem)item).DataContext);
            label.Content = string.Format("I'm on item {0}", i);
        }
    
    }
