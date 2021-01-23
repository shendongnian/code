        this.Size = new Size(800, 800);
        this.tlp.RowCount = 10;
        this.tlp.ColumnCount = 10;
        this.tlp.RowStyles.Clear();
        this.tlp.ColumnStyles.Clear();
        for (int i = 1; i <= this.tlp.RowCount; i++)
        {
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
        }
        for (int i = 1; i <= this.tlp.ColumnCount; i++)
        {
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
        }
