    using OfficeOpenXml;
       private void ExportToExcel()
        {
           
            using (ExcelPackage objExcelPackage = new ExcelPackage())
            {
                
                    //Create the worksheet    
                    ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add("ExcelSheet1");
                          
                DataTable dtQuoteComparison = dt   //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1    
                objWorksheet.Cells["A1"].LoadFromDataTable(dt, true);
                
            
                var start = objWorksheet.Dimension.Start;
                var end = objWorksheet.Dimension.End;
                for (int row = start.Row+1; row <= end.Row; row++) //iterate through rows
                {                    
                   objWorksheet.Cells[rowStart, colStart, rowEnd,colEnd].WhateverProperty=value; 
                }
                objWorksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                objWorksheet.PrinterSettings.FitToWidth = 1;
                //Write it back to the client    
                if (System.IO.File.Exists(filepath))
                    System.IO.File.Delete(filepath);
                //Create excel file on physical disk    
                FileStream objFileStrm = System.IO.File.Create(filepath);
                objFileStrm.Close();
                //Write content to excel file    
                System.IO.File.WriteAllBytes(filepath,objExcelPackage.GetAsByteArray());
            }
        }
