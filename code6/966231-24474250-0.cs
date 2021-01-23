    TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
    int rowCount = 2;
    int columnCount = 2;
    for (int row = 0; row < rowCount; row++)
    {
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        for (int column = 0; column < columnCount; column++)
        {
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            CheckBox checkBox = new CheckBox();
            tableLayoutPanel.Controls.Add(checkBox, column, row);
        }
    }
    this.Controls.Add(tableLayoutPanel);
