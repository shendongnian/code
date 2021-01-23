    public void ExportToExcel(List<Product> products)
    {
      Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
 
      excel.Workbooks.Add();  //Create empty workbook
      Microsoft.Office.Interop.Excel._Worksheet workSheet = excel.ActiveSheet; //Create Worksheet from active sheet
 
      try
      {
        workSheet.Cells[1, "A"] = "Code"; //Set the header
        workSheet.Cells[1, "B"] = "Name";
        workSheet.Cells[1, "C"] = "Price";
        int row = 2; //Start the row
        foreach (Product items in products) //Iterate through a loop
        {
            workSheet.Cells[row, "A"] = items.Code;
            workSheet.Cells[row, "B"] = items.Name;
            workSheet.Cells[row, "C"] = string.Format("{0} Price", items.Price);
 
            row++;
        }
   
        workSheet.Range["A1"].AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1);
 
        string fileName = string.Format(@"{0}\DatainExcel.xlsx", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        workSheet.SaveAs(fileName); //Save data in the file
 
        MessageBox.Show(string.Format("The file '{0}' is saved successfully!", fileName));
    }
    catch (Exception exception)
    {
        MessageBox.Show("Exception", "Problem while saving Excel file!\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
        excel.Quit(); //This is to quit excel
        if (excel != null)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                 
        if (workSheet != null)
                 
        System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                 
        excel = null;
        workSheet = null;
 
        GC.Collect(); //This is to force garbage cleaning
      }
     }
