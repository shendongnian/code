    int columnCount = 4;
    int rowCount = 13;
    this.tableLayoutPanel1.ColumnCount = columnCount;
    this.tableLayoutPanel1.RowCount = rowCount;
    this.tableLayoutPanel1.ColumnStyles.Clear();
    this.tableLayoutPanel1.RowStyles.Clear();
    this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    this.tableLayoutPanel1.BackColor = Color.White;
    this.tableLayoutPanel1.AutoSize = true;
    for (int i = 0; i < columnCount; i++)
    {
        this.tableLayoutPanel1.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 100 / columnCount));
    }
    for (int i = 0; i < rowCount; i++)
    {
        this.tableLayoutPanel1.RowStyles.Add(
            new RowStyle(SizeType.Absolute, 30));
    }
    this.tableLayoutPanel1.SuspendLayout();
    for (var i = 1; i <= 50; i++)
    {
        var label = new Label();
        label.Text = i.ToString();
        label.Font = new Font(label.Font, FontStyle.Bold);
        label.AutoSize = false;
        label.Size = new Size(30, 30);
        label.Image = Properties.Resources.Circle;
        label.ImageAlign = ContentAlignment.MiddleCenter;
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Dock = DockStyle.Fill;
        this.tableLayoutPanel1.Controls.Add(label);
    }
    this.tableLayoutPanel1.ResumeLayout();
