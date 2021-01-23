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
                                rsAddress.Close();
                                return;
                            }
                        }
                    }
                    package.Dispose();
                }
