    private void listView_MouseMove(object sender, MouseEventArgs e)
    {
        var item = VisualTreeHelper.HitTest(listView, Mouse.GetPosition(listView)).VisualHit;
        
        while (item != null && !(item is ListViewItem))
            item = VisualTreeHelper.GetParent(item);
        if (item != null)
        {
            int i = listView.Items.IndexOf(((ListViewItem)item).DataContext);
            label.Content = string.Format("I'm on item {0}", i);
        }
    
    }
