    void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        var grid = (DataGridView)sender;
        //Removes sort glyph 
        this.dataGridView1.Columns.Cast<DataGridViewColumn>()
            .Except(new[] { grid.Columns[e.ColumnIndex] }).ToList()
            .ForEach(c => { c.HeaderCell.SortGlyphDirection = SortOrder.None; });
        //Sort descending if currently sorted ascending
        if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
        {
            originalData.DefaultView.Sort = 
                string.Format("{0} DESC", grid.Columns[e.ColumnIndex].DataPropertyName);
            SetDataSource();
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
        }
        //Sort ascending if currently sorted ascending or not sorted
        else
        {
            originalData.DefaultView.Sort = 
                string.Format("{0} ASC", grid.Columns[e.ColumnIndex].DataPropertyName);
            SetDataSource();
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
        }
    }
