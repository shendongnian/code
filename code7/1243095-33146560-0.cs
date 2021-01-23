    foreach (Range row in Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet.UsedRange.Rows)
    {
        for (int i = 0; i < row.Columns.Count; i++)
        {
            Range cel = row.Cells[1, i + 1];
            if (cel.Value == null || String.IsNullOrEmpty(cel.Value.ToString()))
            {
                cel.Delete();
                i--; // this will do
            }
        }
    }
