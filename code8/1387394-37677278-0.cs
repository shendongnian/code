    Range rngPaste = rngFrom.Offset[0, 1];
    for (int i = 1; i == noPages; i++)
    {
        Range rngCopy = wsBreakdown.Range[rngFrom.Address, rngTo.Address];
        rngCopy.Copy(Type.Missing);
        rngPaste.PasteSpecial(XlPasteType.xlPasteAllUsingSourceTheme, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
        rngTo = wsBreakdown.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
        rngFrom = rngTo.Offset[-24, -9];
        rngPaste = rngFrom.Offset[0, 1];
    }
