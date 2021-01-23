    ExcelFile source = ExcelFile.Load("Source.xlsx");
    ExcelColumn sourceColumn = source.Worksheets[0].Columns[0];
    
    ExcelFile destination = ExcelFile.Load("Destination.xlsx");
    ExcelColumn destinationColumn = destination.Worksheets[0].Columns[0];
    
    int count = source.Worksheets[0].Rows.Count;
    for (int i = 0; i < count; i++)
        destinationColumn.Cells[i].Value = sourceColumn.Cells[i].Value;
    
    destination.Save("Destination.xlsx");
