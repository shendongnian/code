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
                            for (; !rsAddress.EOF; rsAddress.MoveNext())
                            {
                                worksheet.Cells["E2"].Value = "Some string";
                            }
                        }
                    }
                package.Dispose();
                }
