    private void cleanup(Control c)
    {          
        foreach(Control child in c.Controls)        
            cleanup(child);         
          
        if (c.Parent != null)
        {
            c.Parent.Controls.Remove(c);
            c.Dispose();
        }
    }
