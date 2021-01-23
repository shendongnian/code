    Cell cell = new Cell() { CellReference = "A1" };
    CellValue value = new CellValue("\r\nThis text starts with a new line");
    value.Space = SpaceProcessingModeValues.Preserve;
    cell.CellValue = value;
    cell.DataType = new EnumValue<CellValues>(CellValues.String);
