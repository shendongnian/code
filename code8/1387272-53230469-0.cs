    // Load input Excel file inside Aspose.Cells Workbook object.
    Workbook wb = new Workbook("SampleAddPictureInExcelCell.xlsx");
    // Access first worksheet.
    Worksheet ws = wb.Worksheets[0];
    // Access cell C12 by name.
    Cell cell = ws.Cells["C12"];
    // Add picture in Excel cell.
    int idx = ws.Pictures.Add(cell.Row, cell.Column, "D:/Download/Penguins.jpg");
    // Access the picture by index.
    Picture pic = ws.Pictures[idx];
    // Get the column width and row height of the cell in inches.
    double w = ws.Cells.GetColumnWidthInch(cell.Column);
    double h = ws.Cells.GetRowHeightInch(cell.Row);
    // Adjust the picture width and height as per cell width and height.
    pic.WidthInch = w;
    pic.HeightInch = h;
    // Save the workbook in output Excel file.
    wb.Save("OutputAddPictureInExcelCell.xlsx", SaveFormat.Xlsx);
