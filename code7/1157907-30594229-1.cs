    private void GenerateTable(int rowsCount)
            {
                //ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                TextBox1.Text = rowsCount.ToString();
                Table table = new Table();
                table.ID = "Table1";
                PlaceHolder1.Controls.Add(table);
                for (int i = 0; i < rowsCount; i++)
                {
                    TableRow row = new TableRow();
                    row.ID = "Row_" + i;
    for (int j = 0; j < colsCount; j++)
                    {
    if (j < colsCount - 1)
                        {
                            TableCell cell = new TableCell();
                            TextBox tb = new TextBox();
    if (j == 2)
                            {
                                tb.ID = "TextBoxRow_" + i + "Col_" + j;
                                tb.CssClass = "sum"+i;
                                tb.Attributes.Add("onchange", "myFunction();");
                            }
                            else if (j == 3)
                            {
                                tb.ID = "TextBoxRow_" + i + "Col_" + j;
                                tb.CssClass = "sum"+i;
                                tb.Attributes.Add("onchange", "myFunction();");
                            }
                            else if (j == 4)
                            {
                                tb.ID = "TextBoxRow_" + i + "Col_" + j;
                                tb.ReadOnly = true;
                                tb.CssClass = "sum"+i;
                            }
                            cell.Controls.Add(tb);                       
                            row.Cells.Add(cell);
                        }
    table.Rows.Add(row);
                }  
                    SetPreviousData(rowsCount, colsCount);    
                rowsCount++;
                ViewState["RowsCount"] = rowsCount;
            }
