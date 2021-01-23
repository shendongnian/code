            try
            {
               
              
                // Create an instance Excel.
                excelApplication = new xlNS.Application();
                // Open the Excel workbook containing the worksheet with the chart
                // data.
                excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
                                paramMissing, paramMissing, paramMissing,
                                paramMissing, paramMissing, paramMissing,
                                paramMissing, paramMissing, paramMissing,
                                paramMissing, paramMissing, paramMissing,
                                paramMissing, paramMissing);
                // Get the worksheet that contains the chart.
                targetSheet = (xlNS.Worksheet)(excelWorkBook.Worksheets[2]);
                // Get the ChartObjects collection for the sheet.
                chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
                // Create a PowerPoint presentation.
                //pptPresentation = powerpointApplication.Presentations.Add(
                //                    Microsoft.Office.Core.MsoTriState.msoTrue);
                int i = 1;
                foreach (xlNS.ChartObject item in chartObjects)
                {
                    //    // Get the chart to copy.
                    existingChartObject = (xlNS.ChartObject)(item);
                    string chartname = item.Name;
            
                    existingChartObject.CopyPicture(xlNS.XlPictureAppearance.xlScreen, xlNS.XlCopyPictureFormat.xlBitmap);
    // contains in Clipboard so extract from clipboard 
                    if (Clipboard.ContainsImage())
                    {
                  
                        var image = Clipboard.GetData(System.Windows.DataFormats.Bitmap) as Image;
                        if (image != null)
                        {
                            ChartImages.Add(new ImageWithImageName(image, chartname + ".png"));
                        }
                    }
              
                 
                  
                    i++;
                }
           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
              
                // Release the Excel objects.
                targetSheet = null;
                chartObjects = null;
                existingChartObject = null;
                // Close and release the Excel Workbook object.
                if (excelWorkBook != null)
                {
                    excelWorkBook.Close(false, paramMissing, paramMissing);
                    excelWorkBook = null;
                }
                // Quit Excel and release the ApplicationClass object.
                if (excelApplication != null)
                {
                    excelApplication.Quit();
                    excelApplication = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
