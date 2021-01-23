        Microsoft.Office.Interop.Excel._Worksheet worksheet;
        int endColumn = 16384;
        int endRow = 65536;
        var results= new List<Excel.Range>();
        for(var i=0;i<=endColumn;i++)
        {
           for(var j=0;j<=endRow;j++)
           {  
              if(worksheet.Cells[j,i].Interior.Color ==   System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue))
             {
              result.Add(worksheet.Cells[j,i]);
             }
           }
         }
        
