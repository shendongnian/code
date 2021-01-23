    private void Form_Load(object sender, EventArgs e)
    {
        var rowCount = 10;
        var columnCount = 10;
        this.tableLayoutPanel1.ColumnCount = columnCount;
        this.tableLayoutPanel1.RowCount = rowCount;
        this.tableLayoutPanel1.ColumnStyles.Clear();
        this.tableLayoutPanel1.RowStyles.Clear();
        for (int i = 0; i < columnCount; i++)
        {
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount ));
        }
        for (int i = 0; i < rowCount; i++)
        {
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount ));
        }
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                var button = new Button();
                button.Text = string.Format("{0}{1}", i, j);
                button.Name = string.Format("button_{0}{1}", i, j);
                button.Dock = DockStyle.Fill;
                this.tableLayoutPanel1.Controls.Add(button, j, i);
            }
        }
    }
