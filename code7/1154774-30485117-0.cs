    private void GenerateTable(int rowsCount)
            {
                Table table = new Table();
                table.ID = "Table1";
                Page.Form.Controls.Add(table);
                const int colsCount = 3;
    
                 TableHeaderRow header = new TableHeaderRow(); 
                 table.Rows.Add(header); 
                 //These two lines in iteir own loop
                 TableHeaderCell headerTableCell1 = new TableHeaderCell();
                 header.Cells.Add(headerTableCell1);
                for (int i = 0; i < rowsCount; i++)
                {
                    TableRow row = new TableRow();
                    for (int j = 0; j < colsCount; j++)
                    {                    
                        TableCell cell = new TableCell();
                        TextBox tb = new TextBox();
                        tb.ID = "TextBoxRow_" + i + "Col_" + j;
                        cell.Controls.Add(tb);
                        row.Cells.Add(cell);
                    }
                    table.Rows.Add(row);
                }
                SetPreviousData(rowsCount, colsCount);
                rowsCount++;
                ViewState["RowsCount"] = rowsCount;
            }
