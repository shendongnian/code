    private void MarkImportant(object sender, EventArgs e)
    {
        ContextMenu cm = sender as ContextMenu;
        if(cm != null)
        {
            Label lbl = cm.SourceControl as Label;
            if(lbl != null)
            {
                ....
            }
        }
    }
        
