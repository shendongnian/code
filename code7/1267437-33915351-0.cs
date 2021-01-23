    void Main()
    {
      Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
      var workbook = xl.Workbooks.Add();
      Worksheet sht1, sht2;
      sht1 = ((Worksheet)workbook.Sheets[1]);
      if (workbook.Sheets.Count < 2)
      {
        sht2 = (Worksheet)workbook.Sheets.Add();
      }
      else
      {
        sht2 = ((Worksheet)workbook.Sheets[2]);
      }
      xl.Visible = true;
      sht1.Move(sht2);
      
      sht1.Name = "Data Sheet 1";
      sht2.Name = "Data Sheet 2";
    
      string strCon = @"OLEDB;Provider=SQLNCLI11.0;server=.\SQLExpress;Trusted_Connection=yes;Database=Northwind";
    
      Range target1 = (Range)sht1.Range["A1"];
      sht1.QueryTables.Add(strCon, target1, "Select * from Customers" ).Refresh();
    
      Range target2 = (Range)sht2.Range["A1"];
      sht2.QueryTables.Add(strCon, target2, "Select * from Orders").Refresh();
    }
