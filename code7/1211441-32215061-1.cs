        this.Size = new Size(1375, 1375);
        this.tableLayoutPanel1.RowCount = 10;
        this.tableLayoutPanel1.ColumnCount = 10;
        this.tableLayoutPanel1.RowStyles.Clear();
        this.tableLayoutPanel1.ColumnStyles.Clear();
        for (int i = 1; i <= this.tableLayoutPanel1.RowCount; i++)
        {
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
        }
        for (int i = 1; i <= this.tableLayoutPanel1.ColumnCount; i++)
        {
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
        }
