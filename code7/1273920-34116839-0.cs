	if (Request != null)
	{
	   HttpPostedFileBase file = Request.Files[0];
	   if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
	   {
			string fileName = file.FileName;
			string fileContentType = file.ContentType;
			string fileExtension = System.IO.Path.GetExtension(Request.Files[0].FileName);
			if (fileExtension == ".xls" || fileExtension == ".xlsx")
			{
				IExcelDataReader excelReader;
				if (fileExtension == ".xls")
					excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
				else
					excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
				
				excelReader.IsFirstRowAsColumnNames = true;
				DataSet ds = excelReader.AsDataSet();
				
				DataTable Dt = ds.Tables[0];
