    public Form1()
    {
        InitializeComponents();
        
        foreach (TabPage tabPage in TabControl.TabPages)
        {
            tabPage.MouseEnter += (s, e) => tabPage.Focus();
        }
    }
