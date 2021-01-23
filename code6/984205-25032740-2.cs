    protected void OnDataBound(object sender, EventArgs e)
    {
    for (int i = GridView1.Rows.Count - 1; i > 0; i--)
    {
        GridViewRow row = GridView1.Rows[i];
        GridViewRow previousRow = GridView1.Rows[i - 1];
        for (int j = 0; j < row.Cells.Count; j++)
        {
            if (row.Cells[j].Text == previousRow.Cells[j].Text)
            {
                if (previousRow.Cells[j].RowSpan == 0)
                {
                    if (row.Cells[j].RowSpan == 0)
                    {
                        previousRow.Cells[j].RowSpan += 2;
                    }
                    else
                    {
                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                    }
                    row.Cells[j].Visible = false;
                }
            }
        }
    }
    }
