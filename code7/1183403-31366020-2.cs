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
                DataGrid grd = myTabPage.Controls.OfType<DataGridView>().FirstOrDefault();
                if(grd != null)
                {
                    grd.Rows[clickedRow].Cells[0].Value  = false;
                }
            }
        }
    }
