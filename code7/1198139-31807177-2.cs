        private void GetNonNumericValues()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            var x = fd.FileName;
            using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(x, true))
            {
                SharedStringTable sharedStringTable = myDoc.WorkbookPart.SharedStringTablePart.SharedStringTable;
                WorkbookPart workbookPart = myDoc.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData =
                worksheetPart.Worksheet.Elements<SheetData>().First();
                var row = sheetData.Elements<Row>().ToArray()[0];
                
                foreach (Cell c in row.Elements<Cell>())
                {
                    if (c.DataType == CellValues.SharedString)
                    {
                        var cellValue = c.InnerText;
                        MessageBox.Show(sharedStringTable.ElementAt(Int32.Parse(cellValue)).InnerText);
                    }
                }
            }
        }
