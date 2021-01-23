     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == dt.Rows.Count - 1) //dt=Datasource
            {
                e.Row.Cells[0].ColumnSpan = dt.Columns.Count; //your text have to be in cell[0]
                e.Row.Cells[1].Visible = false; //make the other cells invisible
                e.Row.Cells[2].Visible = false;
            }
        }
