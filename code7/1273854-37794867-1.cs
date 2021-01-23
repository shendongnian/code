           string strfilepath = "C:\\Users\\m\\Desktop\\Employeedata.xlsx";           
            using (ExcelPackage p = new ExcelPackage())
            {
                using (FileStream stream = new FileStream(strfilepath, FileMode.Open))
                {
                    p.Load(stream);
                   //deleting worksheet if already present in excel file
                    var wk = p.Workbook.Worksheets.SingleOrDefault(x => x.Name == "Hola");
                    if (wk != null) { p.Workbook.Worksheets.Delete(wk); }
                    
                    p.Workbook.Worksheets.Add("Hola");
                    p.Workbook.Worksheets.MoveToEnd("Hola");
                    ExcelWorksheet worksheet = p.Workbook.Worksheets[p.Workbook.Worksheets.Count];
                    
                    worksheet.InsertRow(5, 2);
                    worksheet.Cells["A9"].LoadFromDataTable(dt1, true);
                    // Inserting values in the 5th row
                    worksheet.Cells["A5"].Value = "12010";
                    worksheet.Cells["B5"].Value = "Drill";
                    worksheet.Cells["C5"].Value = 20;
                    worksheet.Cells["D5"].Value = 8;
                    // Inserting values in the 6th row
                    worksheet.Cells["A6"].Value = "12011";
                    worksheet.Cells["B6"].Value = "Crowbar";
                    worksheet.Cells["C6"].Value = 7;
                    worksheet.Cells["D6"].Value = 23.48;                  
                }
                //p.Save() ;
                Byte[] bin = p.GetAsByteArray();
                File.WriteAllBytes(@"C:\Users\m\Desktop\Employeedata.xlsx", bin);
            }
