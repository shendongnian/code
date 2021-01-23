    // Get a reference to the current item as a tool strip menu item
    ToolStripMenuItem self = (ToolStripMenuItem)sender;
    // Build a list of positions
    List<int> position = new List<int>();
    ToolStripMenuItem cur = self;
    // Keep looping until we don't find a parent
    while (cur != null)
    {
        if (cur.OwnerItem is ToolStripMenuItem)
        {
            // The owner is a menu item, add it's position to our list
            ToolStripMenuItem parent = ((ToolStripMenuItem)cur.OwnerItem);
            position.Insert(0, parent.DropDownItems.IndexOf(cur));
            // And now work on the owner
            cur = parent;
        }
        else
        {
            // The owner isn't a menu item, so break out of our loop
            cur = null;
        }
    }
    // And as a demo, just show the positions:
    MessageBox.Show("You clicked on item at " +
        string.Join(",", position.Select(x => x.ToString()).ToArray()));
