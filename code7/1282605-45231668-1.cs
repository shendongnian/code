    // Save the stylesheet formats
    stylesPart.Stylesheet.Save();
    // Create custom widths for columns
    Columns lstColumns = worksheetPart.Worksheet.GetFirstChild<Columns>();
    Boolean needToInsertColumns = false;
    if (lstColumns == null)
    {
        lstColumns = new Columns();
        needToInsertColumns = true;
    }
    // Min = 1, Max = 1 ==> Apply this to column 1 (A)
    // Min = 2, Max = 2 ==> Apply this to column 2 (B)
    // Width = 25 ==> Set the width to 25
    // CustomWidth = true ==> Tell Excel to use the custom width
    lstColumns.Append(new Column() { Min = 1, Max = 1, Width = 25, CustomWidth = true });
    lstColumns.Append(new Column() { Min = 2, Max = 2, Width = 9, CustomWidth = true });
    lstColumns.Append(new Column() { Min = 3, Max = 3, Width = 9, CustomWidth = true });
    lstColumns.Append(new Column() { Min = 4, Max = 4, Width = 9, CustomWidth = true });
    lstColumns.Append(new Column() { Min = 5, Max = 5, Width = 13, CustomWidth = true });
    lstColumns.Append(new Column() { Min = 6, Max = 6, Width = 17, CustomWidth = true });
    lstColumns.Append(new Column() { Min = 7, Max = 7, Width = 12, CustomWidth = true });
    // Only insert the columns if we had to create a new columns element
    if (needToInsertColumns)
        worksheetPart.Worksheet.InsertAt(lstColumns, 0);
    // Get the sheetData cells
    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
