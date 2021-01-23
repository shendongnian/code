    foreach (GridViewRow row in GridSales.Rows)
    {
        foreach (TableCell cell in row.Cells)
        {
            for (int i = cell.Controls.Count - 1; i >= 0; i--)
            {
                if (cell.Controls[i] is Image)
                {
                    cell.Controls.RemoveAt(i);
                }
            }
        }
    }
