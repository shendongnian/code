    public ActionResult ExportData()
    {
    
        using (ExcelPackage package = new ExcelPackage())
        {
            var ws = package.Workbook.Worksheets.Add("LogMessages");
           //Headers
            ws.Cells["A1"].Value = "Message";
            ws.Cells["B1"].Value = "TimeStamp";
            ws.Cells["C1"].Value = "Level";
    
           var rowNumber=1;
                    
	        foreach (var log in DbContext.Log)
		   {
			   ws.Cells[rowNumber, 1].Value = vehicle.message;
			   ws.Cells[rowNumber, 2].Value = vehicle.timeStamp;
               ws.Cells[rowNumber, 3].Value = vehicle.level;
               rowNumber++;
		   }
            var stream = new MemoryStream();
            package.SaveAs(stream);
    
            string fileName = "logMessags.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    
            stream.Position = 0;
            return File(stream, contentType, fileName);
        }
    }
