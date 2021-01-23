    foreach (GridViewRow row in GridSales.Rows)
    {
        foreach (TableCell cell in row.Cells)
        {
            for (int i = cell.Controls.Count - 1; i >= 0; i--)
            {
                if (cell.Controls[i] is Image)
                {
                    Image img = cell.Controls[i] as Image;
                    // In case you have other images that you want to keep
                    if (img.ImageUrl.Contains("plus.png")) 
                    {
                        cell.Controls.RemoveAt(i);
                    }
                }
            }
        }
    }
