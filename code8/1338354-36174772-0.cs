    //'file' could be a HttpPostedFileBase from client side
    var fileName = Path.GetFileName(file.FileName);
    var physicalPath = Path.Combine(Server.MapPath("~/UploadedPO"), fileName);
    
    file.SaveAs(physicalPath);
    
    Excel.Application excelApp = new Excel.Application();
    Excel.Workbook wb = excelApp.Workbooks.Open(physicalPath,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing);
    Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
    
    
    var app = new Excel.Application();
    Excel.Workbook workbook = wb;
    Excel.Worksheet wsCurrent = ws;
    Excel.XlFileFormat format = Excel.XlFileFormat.xlHtml;
    
    wsCurrent.SaveAs(physicalPath, format);
    
    workbook.Close();
