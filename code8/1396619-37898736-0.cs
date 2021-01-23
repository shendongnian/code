    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                TextBox txt = new TextBox();
                txt.Text = e.Row.Cells[i].Text;
                e.Row.Cells[i].Text = "";
                e.Row.Cells[i].Controls.Add(txt);
            }
        }
        e.Row.Cells.RemoveAt(0); // Removes the first cell in the row
    }
