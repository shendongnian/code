    protected void EXPORT_BUTTON_Click(object sender, EventArgs e)
            {
                using(Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application())
                // creating new WorkBook within Excel application
                 using(Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing))
    			 {
    				String DATA1 = "DATA 1";
    				String DATA2 = "DATA 2";
    				ExportToExcel(app, workbook, DATA1 , DATA_1 );
    				workbook.Worksheets["Sheet1"].Delete();
    				workbook.Worksheets["Sheet2"].Delete();
    				workbook.Worksheets["Sheet3"].Delete();
    				ExportToExcel(app, workbook, DATA2 , DATA_2);
    				workbook.SaveAs(@"C:\Users\testacc\Desktop\Test\" + "Server_" + datetime.ToString("dd-MM-yyyy_hh-mm-ss") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    				var filename = "Report_" + datetime.ToString("dd-MM-yyyy_hh-mm-ss") + ".xlsx";
    				workbook.SaveAs(Server.MapPath("~/Exports/") + filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    				Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    				Response.AddHeader("content-disposition", "attachment, filename=" + filename);
    				workbook.Close();
    				Response.TransmitFile(Server.MapPath("~/Exports/") + filename);
    				Response.End();
    				app.Quit();
    			}
    		}
