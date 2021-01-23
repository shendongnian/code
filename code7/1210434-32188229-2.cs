    using Excel = Microsoft.Office.Interop.Excel;
    // Do lots of Stuff
                    SaveFileDialog saveFD = new SaveFileDialog();
                    saveFD.Filter = "Excel Files|*.xlsx;*.csv;*.xls|All files|*.*";
                    saveFD.FilterIndex = 1;
                    saveFD.RestoreDirectory = true;
                    saveFD.FileName = String.Format("MySavedFile_{0:yyyyMMddHHmmss}.xls", DateTime.Now);
                    if (saveFD.ShowDialog() == DialogResult.OK)
                    {
                        // In this example report is derived from the DevXpress XtraReport class
                        report.ExportToXls(saveFD.FileName);
                        // bote:Mensagem is a derived from devXpress XtraMessageBox
                        if (Mensagem.Confirm("File saved! Open it?"))
                        {
                            try
                            {
                                var excelApp = new Excel.Application();
                                excelApp.Visible = true;
                                var customEvent = new Excel.AppEvents_WorkbookOpenEventHandler(CustomWorkbookOpenEvent);
                                excelApp.WorkbookOpen += customEvent;
                                excelApp.Workbooks.Open(saveFD.FileName,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);}
                            catch (Exception)
                            {
                                Mensagem.Erro("Excel Failed to Open");
                            }
                        }
                    }
