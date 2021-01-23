    public VContainer()
    {
        this.CPanel = new CPanel();
        CPanel.Top = 0;
        CPanel.Left = 0;
        CPanel.Width = 50;
        CPanel.Height = 50;
        this.Controls.Add(CPanel);  // first added Panel**
        this.SPanel = new SPanel();
        SPanel.Top = 50;
        SPanel.Left = 50;
        SPanel.Width = 50;
        SPanel.Height = 50; 
        this.Controls.Add(SPanel);
    }
