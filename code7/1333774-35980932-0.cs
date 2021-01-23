	[HttpGet]
	public void Excel(
		CenturyLinkOrderExcelQueryModel query) {
		var file = Manager.GetExcelFile(query);
		Response.Clear();
		Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
		Response.AddHeader("Content-Disposition", "attachment; filename=" + query.FileName);
		Response.BinaryWrite(System.IO.File.ReadAllBytes(file.FullName));
		Response.Flush();
		Response.Close();
		Response.End();
	}
