            public void writeExcelFile()
            {
    
                try
                {
    
                    String inputFile = @"C:\Users\AAN\Documents\Visual Studio 2015\Projects\WorkWithExcel\WorkWithExcel\bin\Debug\PROJEKTSTATUS_GESAMT_neues_Layout.xlsm";
    
                    Excel.Application oXL = new Excel.Application();
    
    
    #if DEBUG
                    oXL.Visible = true;
                    oXL.DisplayAlerts = true;
    #else
                    oXL.Visible = false; 
                    oXL.DisplayAlerts = false;
    #endif
    
    
                    //Open a Excel File
                    Excel.Workbook oWB = oXL.Workbooks.Add(inputFile);
                    Excel._Worksheet oSheet = oWB.ActiveSheet;
    
                    List<String> Name = new List<String>();
                    List<Double> Percentage = new List<Double>();
    
                    Name.Add("Anil");
                    Name.Add("Vikas");
                    Name.Add("Ashwini");
                    Name.Add("Tobias");
                    Name.Add("Stuti");
                    Name.Add("Raghavendra");
                    Name.Add("Chithra");
                    Name.Add("Glen");
                    Name.Add("Darren");
                    Name.Add("Michael");
    
    
                    Percentage.Add(78.5);
                    Percentage.Add(65.3);
                    Percentage.Add(56);
                    Percentage.Add(56);
                    Percentage.Add(97);
                    Percentage.Add(89);
                    Percentage.Add(85);
                    Percentage.Add(76);
                    Percentage.Add(78);
                    Percentage.Add(89);
    
                    oSheet.Cells[1, 1] = "Name";
                    oSheet.Cells[1, 2] = "Percentage(%)"; // Here 1 is the rowIndex and 2 is the columnIndex.
    
    
                    //Enter the Header data in Column A
                    int i = 0;
                    for (i = 0; i < Name.Count; i++)
                    {
                        oSheet.Cells[i + 2, 1] = Name[i];
                    }
    
                    //Enter the Percentage data in Column B
                    for (i = 0; i < Percentage.Count; i++)
                    {
                        oSheet.Cells[i + 2, 2] = Percentage[i];
                    }
    
                    oSheet.Cells[Name.Count + 3, 1] = "AVERAGE";
                    //Obtain the Average of the Percentage Data
                    string currentFormula = "=AVERAGE(B2:" + "B" + Convert.ToString(Percentage.Count + 1) + ")";
    
                    oSheet.Cells[Percentage.Count + 3, 2].Formula = currentFormula;
    
                    //Format the Header row to make it Bold and blue
                    oSheet.get_Range("A1", "B1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.AliceBlue);
                    oSheet.get_Range("A1", "B1").Font.Bold = true;
                    //Set the column widthe of Column A and Column B to 20
                    oSheet.get_Range("A1", "B12").ColumnWidth = 20;
    
                    //String ReportFile = @"D:\Excel\Output.xls";
                    oWB.SaveAs(inputFile, Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled,
                                            Type.Missing, Type.Missing,
                                            false,
                                            false,
                                            Excel.XlSaveAsAccessMode.xlNoChange,
                                            Type.Missing,
                                            Type.Missing,
                                            Type.Missing,
                                            Type.Missing,
                                            Type.Missing);
    
    
                    oXL.Quit();
    
                    Marshal.ReleaseComObject(oSheet);
                    Marshal.ReleaseComObject(oWB);
                    Marshal.ReleaseComObject(oXL);
    
                    oSheet = null;
                    oWB = null;
                    oXL = null;
                    GC.GetTotalMemory(false);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.GetTotalMemory(true);
                }
                catch (Exception ex)
                {
                    String errorMessage = "Error reading the Excel file : " + ex.Message;
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
            }
