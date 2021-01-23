    public void makeTable()
        {
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
           
    
            //loop that creates the requiret amount of rows in table
           for (int i = 0; i <= 4; i++)
           {
              panel.Controls.Add(new Label() { Text = i + "" }, 0, i);
              panel.Controls.Add(new Label() { Text = i + "" }, 1, i);
              panel.Controls.Add(new Label() { Text = i + "" }, 2, i);
           }
            this.Controls.Add(panel);
        }
 
