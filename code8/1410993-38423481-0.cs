     class Program
        {
            static void Main(string[] args)
            {
    
                // Set the File name and get the output directory
    
                var fileName = "Example-File-" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".xlsx";
                var outputDir = @"E:\C#Programming\ExcelFormattingProject\outpath\" + fileName;
    
                DataTable dt = new DataTable();
    
                // Create the file using the FileInfo object
                var file = new FileInfo(outputDir);
    
                using (var package = new ExcelPackage(file))
                {
                    // Adding a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Example list - " + DateTime.Now.ToShortDateString());
    
                    // --------- Data and styling goes here -------------- //
    
                    // Header part
    
                    worksheet.Cells["A1"].Value = "Field1";
                    worksheet.Cells["B1"].Value = "Field2";
                    worksheet.Cells["C1"].Value = "Field3";
                    worksheet.Cells["D1"].Value = "Field4";
                    worksheet.Cells["E1"].Value = "Field5";
    
                    worksheet.Cells["A1:E1"].Style.Font.Bold = true;
    
                    // The row number 
                    int initialRowNum = 2;
                    int rowNumber = initialRowNum;
    
                    #region input_toExcel
    
                    // Filling the data from the 2nd row of the excel sheet
    
                    worksheet.Cells[rowNumber, 1].Value = "1";
                    worksheet.Cells[rowNumber, 2].Value = "GRP";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "2.1";
                    worksheet.Cells[rowNumber, 2].Value = "Item2.1";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "1.2";
                    worksheet.Cells[rowNumber, 2].Value = "Item1.2";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "1.3";
                    worksheet.Cells[rowNumber, 2].Value = "Item";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "1.4";
                    worksheet.Cells[rowNumber, 2].Value = "Item";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "2";
                    worksheet.Cells[rowNumber, 2].Value = "GRP";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "1.1";
                    worksheet.Cells[rowNumber, 2].Value = "Item";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "2.2";
                    worksheet.Cells[rowNumber, 2].Value = "Item";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "2.3";
                    worksheet.Cells[rowNumber, 2].Value = "Item";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
    
                    rowNumber++;
    
                    worksheet.Cells[rowNumber, 1].Value = "2.4";
                    worksheet.Cells[rowNumber, 2].Value = "Item";
                    worksheet.Cells[rowNumber, 3].Value = "ABC";
                    worksheet.Cells[rowNumber, 4].Value = "CDE";
                    worksheet.Cells[rowNumber, 5].Value = "ABCD";
    
    
                       
                    #endregion
    
                    //  Need to fetch the data as a row or recorset and then sort it and place it to a new Excel
    
                    //worksheet.Cells["A2:A11"].Style.Numberformat.Format = "#0\\.00";
    
                    for (var rowIndex = 1;rowIndex < 11; rowIndex++)
                    {
                        var colIndex = 1;
                       
                        for (; colIndex <= 5;)
                        {
                            // Filling the First Row of the DataTable with the Field Name as on the Excel Sheet
                            if (rowIndex == 1)
                            {
                                dt.Columns.Add(new DataColumn(worksheet.Cells[rowIndex, colIndex].Text));
                            }
                            else
                            {
                                dt.Columns.Add(new DataColumn());
                            }
                            colIndex++;
                        }
                        dt.Rows.Add(dt.NewRow());
                    }
    
                    // Inserting Values in the DataTable
                    for (var rowIndex = 1; rowIndex < 11; rowIndex++)
                    {
                            // Filling the DataTable with Excel Contents
                            for (var colIndex = 1; colIndex <= 5;)
                            {
                                    dt.Rows[rowIndex - 1][colIndex - 1] = worksheet.Cells[rowIndex+1, colIndex].Text;
                                    colIndex++;
                            }
                    }
    
                    // Sorting the DataTable 
                    DataTable dtOut = null;
                    dt.DefaultView.ToTable(false, "Field1", "Field2", "Field3", "Field4", "Field5");
                    dt.DefaultView.Sort = "Field1";
                    dtOut = dt.DefaultView.ToTable(false, "Field1", "Field2","Field3","Field4","Field5");
    
                    
                    // Exporting the DataTable to the WorkSheet of the Excel
                    worksheet.Cells["A1"].LoadFromDataTable(dtOut, true);
    
                    
    
                    #endregion
    
                    // Grouping after comparing the Cell Value 
                    for ( var rowIndex = 2; worksheet.Row(rowIndex) != null; rowIndex++)
                      {
                        // Checking for NULL in the Excel Sheet
                        var comapreable = worksheet.Cells[rowIndex, 1].GetValue<string>();
    
                        // Group Counter 
                        int count = 0;
    
                        if (comapreable != null)
                        {
                            Regex regexIntegral = new Regex(@"\d");
                            Match matchIntegral = regexIntegral.Match(comapreable);
    
                            Regex regexDouble = new Regex(@"([1-9]+)\.([1-9]+)");
                            Match matchDouble = regexDouble.Match(comapreable);
                            
    
                            // Checking if the Cell of the Excel sheet contains any integral value
                            if ( matchIntegral.Success == true )
                            {
                                count++; // Incrementing the Group Level Counter
    
                                // Checking if the Cell contains the decimal values
    
                                if ( matchDouble.Success == true )
                                {
                                    worksheet.Row(rowIndex).OutlineLevel = count;
                                    worksheet.Row(rowIndex).Collapsed = true;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    // Saving the File
                    package.Save();
                }
                // Console.ReadKey();
            }
            
        }
