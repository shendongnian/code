    DataTable table;
    private void Form1_Load(object sender, EventArgs e)
    {
        table = GetData();
        this.dataGridView1.AllowUserToAddRows = false;
        this.dataGridView1.AllowUserToDeleteRows = false;
        this.dataGridView1.ReadOnly = true;
        this.dataGridView1.RowHeadersVisible = false;
        this.dataGridView1.ColumnHeadersVisible = false;
        this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        this.dataGridView1.RowTemplate.Height = 64;
        this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        this.dataGridView1.ColumnCount = (int)table.Compute("Max(ColNum)", "");
        this.dataGridView1.RowCount = (int)table.Compute("Max(RowNum)", "");
    }
    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex >= 0 & e.ColumnIndex >= 0)
        {
            var row = table.Select(string.Format("RowNum={0} AND ColNum={1}",
                e.RowIndex + 1, e.ColumnIndex + 1)).FirstOrDefault();
            if (row != null)
            {
                e.Value = row["EmpId"];
                var color = (Color)new ColorConverter().ConvertFrom(row["BG_Color"]);
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionBackColor = color;
                e.CellStyle.SelectionForeColor = Color.Black;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
