    private void ListenToolStripMenuItems(IEnumerable<ToolStripMenuItem> menuItems)
    {
        // listen all menuItems
        foreach (ToolStrip menuItem in menuItems)
            menuItem.DropDown.Closing += OnToolStripDropDownClosing;
    }
    private void OnToolStripDropDownClosing(object sender, ToolStripDropDownClosingEventArgs e)
    {
            var tsdd = sender as ToolStripDropDown;      // casting
            // checking if mouse it's inside
            Point p = tsdd.PointToClient(MousePosition);  
            if (tsdd.DisplayRectangle.Contains(p))
                e.Cancel = true;  // cancel closing
    }
