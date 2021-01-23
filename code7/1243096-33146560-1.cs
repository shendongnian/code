    foreach (Range row in Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet.UsedRange.Rows)
    {
        for (int i = 0; i < row.Columns.Count; i++)
        {
            Range cel = row.Cells[1, i + 1];
            if (cel.Value == null || String.IsNullOrEmpty(cel.Value.ToString()))
            {
                // default shift is up
                cel.Delete();
                // to shift left use cel.Delete(XlDeleteShiftDirection.xlShiftToLeft);
                i--; // this will do
            }
        }
    }
