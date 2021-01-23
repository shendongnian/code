    xlApp = new Excel.Application();
                        xlWorkbook = xlApp.Workbooks.Open(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        xlSheet = (Excel.Worksheet)xlWorkbook.Sheets[1]; // get first sheet
                        Excel.Range currentFind = null;
                        Excel.Range xlRange = null;
                        xlRange = xlSheet.UsedRange;
