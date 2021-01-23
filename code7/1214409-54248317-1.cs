        foreach (var item in census)
                   {
                    //how to write the data in cell
                    Row refRow = GetRow(sheetData, rowIndex);
                    ++rowIndex;
        
                    Cell cell1 = new Cell() { CellReference = "A" + rowIndex };
                    CellValue cellValue1 = new CellValue();
                    cellValue1.Text = "";
                    cell1.Append(cellValue1);
                    Row newRow = new Row()
                    {
                        RowIndex = rowIndex
                    };
                    newRow.Append(cell1);
                    for (int i = (int)rowIndex; i <= sheetData.Elements<Row>().Count(); i++)
                    {
                        var row = sheetData.Elements<Row>().Where(r => r.RowIndex.Value == i).FirstOrDefault();
                        row.RowIndex++;
                        foreach (Cell c in row.Elements<Cell>())
                        {
                            string refer = c.CellReference.Value;
                            int num = Convert.ToInt32(Regex.Replace(refer, @"[^\d]*", ""));
                            num++;
                            string letters = Regex.Replace(refer, @"[^A-Z]*", "");
                            c.CellReference.Value = letters + num;
                        }
                    }
                    sheetData.InsertAfter(newRow, refRow);
                          rowindex++;
                   }
    static Row GetRow(SheetData wsData, UInt32 rowIndex)
        {
            var row = wsData.Elements<Row>().
            Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
            if (row == null)
            {
                row = new Row();
                row.RowIndex = rowIndex;
                wsData.Append(row);
            }
            return row;
        }
