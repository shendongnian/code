                FileInfo AddressList = new FileInfo("c:\temp\test.xlsx);
                using (ExcelPackage package = new ExcelPackage(AddressList))
                {
                    // Get the work book in the file
                    ExcelWorkbook workBook = package.Workbook;
                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            // Get the first worksheet
                            //ExcelWorksheet Worksheet = workBook.Worksheets.First();
                            var worksheet = package.Workbook.Worksheets[1];
                            if (worksheet.Cells["A1"].Value.ToString() != "Address")
                            {
                                MessageBox.Show("The cell A1 should say Address. Aborting.");
                                return;
                            }
                            // This is a safe way to make sure a null cell will not cause you an error.
					        string callValue = worksheet.Cells["E2"].Value == null ? string.Empty : worksheet.Cells["E2"].Value.ToString();
					        if (string.IsNullOrEmpty(strTerminal.Trim()) == false)
					        {
						        MessageBox.Show(callValue.ToString());
					        }
                        }
                    }
                    package.Dispose();
                }
