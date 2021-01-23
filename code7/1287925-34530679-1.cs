     TableLayoutPanel panel = new TableLayoutPanel();
            panel.Top = 100;
            panel.Left = 30;
            panel.ColumnCount = 3;
            panel.Width = 690;
            panel.Height = 275;
            panel.RowCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            panel.Controls.Add(new Label() { Text = 01 + "" }, 0, 0);
            panel.Controls.Add(new Label() { Text = 02 + "" }, 1, 0);
            panel.Controls.Add(new Label() { Text = 03 + "" }, 2, 0);
    
            //loop that creates the requiret amount of rows in table
            int i = 0;
            while (i < 4)
            {
                panel.RowCount++;
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                panel.Controls.Add(new Label() { Text = i + 1 + "" }, 0, panel.RowCount - 1);
                panel.Controls.Add(new Label() { Text = i + 1 + "" }, 1, panel.RowCount - 1);
                panel.Controls.Add(new Label() { Text = i + 1 + "" }, 2, panel.RowCount - 1);
                i++;
            }
            this.Controls.Add(panel);
