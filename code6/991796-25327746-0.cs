    public static byte[] DoConvertXlDataToOpenXml(byte[] data, FileInfo fileInfo)
            {
                ExcelInterop.Application excelApp = null;
                ExcelInterop.Workbooks workBooks = null;
                ExcelInterop.Workbook workBook = null;
                FileInfo tempFile = null;
                FileInfo convertedTempFile = null;
    
                try
                {
                    //Stream the file to temporary location, overwrite if exists
                    tempFile = new FileInfo(Path.ChangeExtension(Path.Combine(Path.GetTempFileName()), fileInfo.Extension));
    
                    using (var destStream = new FileStream(tempFile.FullName, FileMode.Create, FileAccess.Write))
                    {
                        destStream.Write(data, 0, data.Length);
                    }
    
                    //open original
                    excelApp = new ExcelInterop.Application();
                    excelApp.Visible = false;
                    excelApp.DisplayAlerts = false;
    
                    workBooks = excelApp.Workbooks;
                  
                    workBook = workBooks.Open(tempFile.FullName);
    
                    convertedTempFile = new FileInfo(Path.ChangeExtension(Path.GetTempFileName(), "XLSX"));
    
                    //Save as XLSX
                    excelApp.Application.ActiveWorkbook.SaveAs(
                         convertedTempFile.FullName
                         , Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook
                         , ConflictResolution: ExcelInterop.XlSaveConflictResolution.xlLocalSessionChanges);
    
                    excelApp.Application.ActiveWorkbook.Close();
    
                    return File.ReadAllBytes(convertedTempFile.FullName);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (workBooks != null)
                        Marshal.ReleaseComObject(workBooks);
    
                    if (workBook != null)
                        Marshal.ReleaseComObject(workBook);
    
                    if (excelApp != null)
                        Marshal.ReleaseComObject(excelApp);
    
                    if (tempFile != null && tempFile.Exists)
                        tempFile.Delete();
    
                    if (convertedTempFile != null && convertedTempFile.Exists)
                    {
                        convertedTempFile.Delete();
                    }
                }
            }
