    foreach (Excel.Range row in rows)
    {
        if (row.Cells.EntireRow.Interior.ColorIndex == 0) // changed = to ==
        {
            row.Interior.Color = System.Drawing.Color.Red;
        }
    }
