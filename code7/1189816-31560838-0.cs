    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(@"C:\Users\MyPath\Desktop\ColorBook.xls");
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets["DailyWork"];
                    Excel.Range usedRange = worksheet.UsedRange;
                    Excel.Range rows = usedRange.Rows;
                    try
                    {
                        foreach (Excel.Range row in rows)
                        {
                            if (row.Cells.EntireRow.Interior.ColorIndex == -4142)
                            {
                                row.Interior.Color = System.Drawing.Color.Red;
                            }
                        }
                        workbook.Save();
                        workbook.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
