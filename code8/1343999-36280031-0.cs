    private void btnExcel_Click(object sender, System.EventArgs e)
    {
    	var fileName = "C:/Users/Me/Documents/CApplicationTemplate.xlsx";
    	System.IO.MemoryStream ms = new System.IO.MemoryStream();
    	using (var fs = File.OpenRead(fileName))
    	{
    		ms.SetLength(fs.Length);
    		fs.Read(ms.GetBuffer(), 0, Convert.ToInt32(fs.Length));
    	}
    
    	//Clear headers
    	Response.ClearHeaders();
    	Response.ClearContent();
    	Response.Clear();
    	//Add my send my xlsx file
    	Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml";
    	Response.AddHeader("Content-Disposition", "attachment; filename=CApplicationTemplate.xlsx");
    	Response.AddHeader("Cache-Control", "must-revalidate, post-check=0, pre-check=0");
    	Response.AddHeader("Pragma", "no-cache");
    	Response.AddHeader("Expires", "0");
    	ms.WriteTo(Response.OutputStream);
    
    	Response.Flush();
    	ms.Dispose();
    }
