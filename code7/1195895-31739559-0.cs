     Microsoft.Office.Interop.Excel.Workbook CurrentWk = ((Microsoft.Office.Interop.Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook);
                            if (Path.GetExtension(CurrentWk.Name) != ".xlsx")
                            {
                                MessageBox.Show("Please save the document before complete this task", "warning");
                            }
                            else
                            {
                                Microsoft.Office.Interop.Excel.Workbook workbook = Globals.ThisAddIn.Application.Workbooks.Open(IdsTemplatePath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, false, false);
                                Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                                totalSheet = workbook.Worksheets.Count;
                                for (int sheetNum = 1; sheetNum <= totalSheet; sheetNum++)
                                {
                                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[sheetNum];
                                    sheetname = worksheet.Name.Replace("\r", "").Replace("\a", "").Trim().ToLower();
                                    if (sheetname == "ids_template")
                                    {
                                        try
                                        {
                                            worksheet.Copy(CurrentWk.Sheets[1]);
                                            workbook.Close(SaveChanges, Type.Missing, Type.Missing);
                                        }
                                        catch { }
                                        ids_template_found = true;//here it is set true because template sheet is added above in current workbook.
                                        break;
                                    }
                                }
                            }
