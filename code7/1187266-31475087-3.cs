    (Control)thePanel.KeyPress += new KeyPressEventHandler(ThePanel_KeyPress);
    public void ThePanel_KeyPress(Object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Escape) ... // Do something
    }
    
    
