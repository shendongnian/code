    private void FindTag(Control.ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            if (c.Tag != null)
            //logic
    
           if (c.HasChildren)
               FindTag(c.Controls); //Recursively check all children controls as well; ie groupboxes or tabpages
        }
    }
