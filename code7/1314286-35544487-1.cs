    public static class Extensions
    {
    	 internal static void ExportToXcel_SomeReport(DataTable dt, string fileName, Page page)
    	{
    		var recCount = dt.Rows.Count;
    		RemoveHtmlSpecialChars(dt);
    		fileName = string.Format(fileName, DateTime.Now.ToString("MMddyyyy_hhmmss"));
    		var xlsx = new XLWorkbook();
    		var ws = xlsx.Worksheets.Add("Some Report Name");
    		ws.Style.Font.Bold = true;
    		ws.Cell("C5").Value = "YOUR REPORT NAME";
    		ws.Cell("C5").Style.Font.FontColor = XLColor.Black;
    		ws.Cell("C5").Style.Font.SetFontSize(16.0);
    		ws.Cell("E5").Value = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
    		ws.Range("C5:E5").Style.Font.SetFontSize(16.0);
    		ws.Cell("A7").Value = string.Format("{0} Records", recCount);
    		ws.Style.Font.Bold = false;
    		ws.Cell(9, 1).InsertTable(dt.AsEnumerable());
    		ws.Row(9).InsertRowsBelow(1);
    	   // ws.Style.Font.FontColor = XLColor.Gray;
    		ws.Columns("1-9").AdjustToContents();
    		ws.Tables.Table(0).ShowAutoFilter = true;
    		ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
    		DynaGenExcelFile(fileName, page, xlsx);
    	}
    	
    	
    	/// <summary>
    	/// Remove all HTML special characters from datatable field if they are present 
    	/// </summary>
    	/// <param name="dt"></param>
    	private static void RemoveHtmlSpecialChars(DataTable dt)
    	{
    		for (int rows = 0; rows < dt.Rows.Count; rows++)
    		{
    			for (int column = 0; column < dt.Columns.Count; column++)
    			{
    				dt.Rows[rows][column] = dt.Rows[rows][column].ToString().Replace("&nbsp;", string.Empty);
    			}
    		}
    	}
    
    	/// <summary>
    	/// Call this Method to Generate the Excel Files from different Lap Reports depending on which one has been selected
    	/// </summary>
    	/// <param name="fileName"></param>
    	/// <param name="page"></param>
    	/// <param name="xlsx"></param>
    	private static void DynaGenExcelFile(string fileName, Page page, XLWorkbook xlsx)
    	{
    		page.Response.ClearContent();
    		page.Response.ClearHeaders();
    		page.Response.ContentType = "application/vnd.ms-excel";
    		page.Response.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", fileName));
    
    		using (MemoryStream memoryStream = new MemoryStream())
    		{
    			xlsx.SaveAs(memoryStream);
    			memoryStream.WriteTo(page.Response.OutputStream);
    			memoryStream.Close();
    		}
    		page.Response.Flush();
    		page.Response.End();
    	}	
    	
    }
