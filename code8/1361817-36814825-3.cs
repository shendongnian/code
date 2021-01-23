    private void MarkImportant(object sender, EventArgs e)
    {
        // Convert the sender object to a MenuItem 
        MenuItem mi = sender as MenuItem;
        if(mi != null)
        {
            // Get the parent of the MenuItem (the ContextMenu) 
            // and read the SourceControl as a label
            Label lbl = (mi.Parent as ContextMenu).SourceControl as Label;
            if(lbl != null)
            {
                ....
            }
        }
    }
        
