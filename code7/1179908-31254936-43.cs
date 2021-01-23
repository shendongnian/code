                FileInfo AddressList = new FileInfo("c:\\temp\\test.xlsx");
                using (ExcelPackage package = new ExcelPackage(AddressList))
                {
                    // Get the work book in the file
                    ExcelWorkbook workBook = package.Workbook;
                    if (workBook != null)
                    {
                        if (workBook.Worksheets.Count > 0)
                        {
                            // Get the first worksheet
                            var worksheet = package.Workbook.Worksheets[1];
                            worksheet.Cells["D2"].Value = "Some other string";
                            worksheet.Cells["E2"].Value = "Some string";
                        }
                    }
                    try
                    {
                        package.Save();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error saving the spreadsheet.     " + ex);
                        MessageBox.Show("Error saving the spreadsheet.  Do you have it open?");
                        return;
                    }
                }
