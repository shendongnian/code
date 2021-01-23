    var panel = new TableLayoutPanel();
    panel.ColumnCount = 3;
    panel.RowCount = 4;
    
    for(int i = 0; i< panel.ColumnCount; ++i)
        panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
    
    for (int i = 0; i < panel.RowCount; ++i)
        panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
    
    panel.Dock = DockStyle.Fill;
    this.Controls.Add(panel);
    
    for (int c = 0; c < 3; ++c)
    {
        for (int r = 0; r < 4; ++r)
        {
            var btn = new Button();
            btn.Text = (c+r).ToString();
            btn.Dock = DockStyle.Fill;
            panel.Controls.Add(btn, c, r);
        }
    }
