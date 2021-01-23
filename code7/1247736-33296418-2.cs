    public void ExportToExcel()
    {
    	//for export
    	var objExcelPackage = new ExcelPackage(); //create new workbook
    
    	this.ListFiles(objExcelPackage, 0, @"C:\Images");
    	
    	var filepath = new FileInfo(@"C:\Users\user\Desktop\Test\" + datetime.ToString("dd-MM-yyyy_hh-mm-ss") + ".xlsx");
    	objExcelPackage.SaveAs(filepath);
    }
    
    public void ListFiles(ExcelPackage objExcelPackage, int worksheetIndex, string path)
    {
    	var imageCount = 0;
    	var x = 25;
    	var finalValue = 0;
    	
		var files = Directory.GetFiles(path).Select(s => new FileInfo(s));
		
		if (files.Any())
		{
			//create new worksheet
			var ws = objExcelPackage.Workbook.Worksheets.Add("Worksheet" + (++worksheetIndex)); 
			
			foreach (var file in files)
			{
				imageCount++;
				
				var TEST_IMAGE = new System.Web.UI.WebControls.Image();
				var myImage = System.Drawing.Image.FromFile(img);
				var pic = ws.Drawings.AddPicture(imageCount.ToString(), myImage);
				
				// Row, RowoffsetPixel, Column, ColumnOffSetPixel
				if (imageCount > 1)
				{
					pic.SetPosition(finalValue, 0, 2, 0);
					finalValue += (x + 1); // Add 1 to have 1 row of empty row
				}
				else
				{
					pic.SetPosition(imageCount, 0, 2, 0);
					finalValue = (imageCount + x) + 1; // Add 1 to have 1 row of empty
				}
			}
		}
		
    	foreach (var dir in Directory.GetDirectories(path))
    	{
    		this.ListFiles(objExcelPackage, worksheetIndex, dir);
    	}
    }
