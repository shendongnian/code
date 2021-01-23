    // Create a new "workbook set".
    IWorkbookSet wbs = Factory.GetWorkbookSet();
    // Add a workbook under this "workbook set".
    IWorkbook workbook = wbs.Workbooks.Add();
    IWorksheet worksheet = workbook.ActiveWorksheet;
    // Do your task (here I just insert single characters into cells in the sheet).
    Parallel.ForEach("ABCDEFG", (char c) => {
        // Must acquire a workbook set lock before doing anything to the workbook!
        wbs.GetLock();
        try
        {
            // Get next row to add character.
            int nextRow = worksheet.UsedRange.Row + worksheet.UsedRange.RowCount;
            // Add character to cell.
            worksheet.Cells[nextRow, 0].Value = c;
        }
        finally
        {
            // Must release the workbook set lock.
            wbs.ReleaseLock();
        }
    });
