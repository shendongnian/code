    public class Tyburn1
    {
        object missing = Type.Missing;
        public Tyburn1()
        {
            Excel.Application oXL = new Excel.Application();
            oXL.Visible = false;
            Excel.Workbook oWB = oXL.Workbooks.Add(missing);
            Excel.Worksheet oSheet = oWB.ActiveSheet as Excel.Worksheet;
            oSheet.Name = "The first sheet";
            oSheet.Cells[1, 1] = "Something";
            Excel.Worksheet oSheet2 = oWB.Sheets.Add(missing, missing, 1, missing) 
                            as Excel.Worksheet;
            oSheet2.Name = "The second sheet";
            oSheet2.Cells[1, 1] = "Something completely different";
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)        
                                    + "\\SoSample.xlsx";
            oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook,
                missing, missing, missing, missing,
                Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
            oWB.Close(missing, missing, missing);
            oXL.UserControl = true;
            oXL.Quit();
        }
    }
