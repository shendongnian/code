    private void export()
            {
                Microsoft.Office.Interop.Excel.Application oXL;
                Microsoft.Office.Interop.Excel._Workbook oWB;
                Microsoft.Office.Interop.Excel._Worksheet oSheet;
                object misvalue = System.Reflection.Missing.Value;
    
              try
              {
                  oXL = new Microsoft.Office.Interop.Excel.Application();
                  oXL.Visible = true;
                  oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Open(libro));
                  oWB.Sheets[x].Select(); 
                  //x is the number of the sheet where you want to save data.
                  oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
    
    //This goes into a for
    oSheet.get_Range(tmp, misvalue).Value2 = values[x]; //tmp is a string, which contains letter and number of the cell "A1". misvalue is an object variable
        oWB.Save();
                        oWB.Close();
                        oXL.Visible = false;
                        oXL.UserControl = false;
                        oXL.Application.Quit();
        }
        catch(Exception exc){}
        }
