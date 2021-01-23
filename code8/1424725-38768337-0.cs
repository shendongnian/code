    var panel = new TableLayoutPanel();
    panel.RowCount = 1;
    panel.ColumnCount = 3;
    panel.Controls.Add(new Button());
    panel.Controls.Add(new TextBox());
    panel.Controls.Add(new Button());
    panel.Controls[0].Text = "Button1";
    panel.Controls[2].Text = "Button2";
    panel.Controls[1].Dock = DockStyle.Fill;
    panel.Dock = DockStyle.Fill;
    
    panel.ColumnStyles.Clear();
    panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // This is the changed part
    panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
