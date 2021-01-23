    private void MarkImportant(object sender, EventArgs e)
    {
        // Convert to a MenuItem the sender object
        MenuItem mi = sender as MenuItem;
        if(mi != null)
        {
            // Get the parent (the ContextMenu) and read the SourceControl as a label
            Label lbl = (mi.Parent as ContextMenu).SourceControl as Label;
            if(lbl != null)
            {
                ....
            }
        }
    }
        
