    protected void GridView1_DataBound1(object sender, System.EventArgs e)
    {
        for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridView1.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {
                if (gvRow.Cells[cellCount].Text ==
                                    gvPreviousRow.Cells[cellCount].Text)
                {
                    if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                    {
                        gvRow.Cells[cellCount].RowSpan = 2;
                    }
                    else
                    {
                        gvRow.Cells[cellCount].RowSpan =
                            gvPreviousRow.Cells[cellCount].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[cellCount].Visible = false;
                }
            }
        }
    }
