    private static readonly int WIDTH_FOR_ITEM_DESC_COL = 42;
    . . .
    _xlSheet.Columns.AutoFit();
    // The AutoFitting works pretty well, but one column needs to be manually tweaked due to potentially over-long Descriptions
    ((Range)_xlSheet.Cells[1, 1]).EntireColumn.ColumnWidth =  WIDTH_FOR_ITEM_DESC_COL;
