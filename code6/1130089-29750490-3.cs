    foreach(GridViewRow row in GridView1.Rows)
    {
        for(int i = 0; i < GridView1.Columns.Count, i++)
        {
            if(!String.IsNullOrempty(row.Cells[i].Text))
            {
                row.Cells[i].Text = "null";
            }
        }
    }
