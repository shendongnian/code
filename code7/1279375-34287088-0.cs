    protected void gvResults_RowCreated(object sender, GridViewRowEventArgs e)
    {
        for (int i = 8; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[i].Visible = false;
        }
    }
