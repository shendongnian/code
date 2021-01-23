    void Form1_Load(object sender, EventArgs e)
    {
        Random r = new Random();
        var dt = new DataTable();
        dt.Columns.Add("A", typeof(int));
        dt.Columns.Add("B", typeof(int));
        for (int i = 0; i < 10; i++)
            dt.Rows.Add(r.Next(100));
        grid.DataSource = dt;
        grid.CellFormatting += grid_CellFormatting;
        grid.CellEndEdit += grid_CellEndEdit;
    }
    void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        grid.Invalidate();
    }
    void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var grid = sender as DataGridView;
        var parameterColumnName = "A";       //Parameter column name
        var start = 0;                       //Start row index for formula
        var end = grid.RowCount - 1;         //End row index for formula
        var resultRowIndex = 0;              //Result row index
        var resultColumnName = "B";          //Result column name
        if (e.RowIndex == resultRowIndex &&
            grid.Columns[e.ColumnIndex].Name == resultColumnName)
        {
            var list = Enumerable.Range(start, end - start + 1)
                  .Select(i => grid.Rows[i].Cells[parameterColumnName].Value)
                  .Where(x => x != null && x != DBNull.Value)
                  .Cast<int>();
            if (list.Any())
                e.Value = list.Max();
        }
    }
