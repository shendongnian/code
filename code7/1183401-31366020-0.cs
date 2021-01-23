    void myDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        int clickedRow = e.RowIndex;
        int clickedColumn = e.ColumnIndex;
        if (clickedColumn != 0) return;
        DataGridView myDataGridView = (DataGridView)sender;
        if (!ToggleAllRowSelection)
        {
            foreach (TabPage myTabPage in tabControl1.TabPages)
            {
                DataGrid grd = myTabPage.Controls.OfType<DataGrid>().FirstOrDefault();
                if(grd != null)
                {
                    grd.Row[clickedRow].Cells[0].Value  = false;
                }
            }
        }
    }
