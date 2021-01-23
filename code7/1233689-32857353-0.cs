    int curretCol = System.Array.FindIndex<string>(clmAry, (string r) => r.ToString() == "account_no");
                    int currentrow = 1;
    
                    foreach (GLSearchDC content in GLList)
                    {
                        Cell cell = worksheet.Cells[CellsHelper.CellIndexToName(currentrow++, curretCol)];
                      
                            cell.PutValue(string.Format("=\"{0}\"", content.Account_No));
                        content.account_no));
                    }
