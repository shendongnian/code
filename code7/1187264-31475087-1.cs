    (Control)thePanel.KeyPress += new KeyPressEventHandler(ThePanel_KeyPress);
    public void ThePanel_KeyPress(Object sender, KeyPressEventArgs e)
    {
        if (e.KeyCode == Keys.Escape) ... // Dosomething
    }
    
    
