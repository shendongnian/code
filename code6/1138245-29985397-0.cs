	try
	{
		if (FlUploadcsv.HasFile)
		{
			OleDbConnection OleDbcon;
			OleDbCommand cmd = new OleDbCommand(); ;
			OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
			DataSet ds = new DataSet();
			DataTable dtExcelData = new DataTable();
		
			string FileName = FlUploadcsv.FileName;
			string filePath = "C:\\Users\\admin\\Desktop\\Sheet1.xlsx";
			string path = filePath;// string.Concat(Server.MapPath("~/Document/" + FlUploadcsv.FileName));
			FlUploadcsv.PostedFile.SaveAs(path);
			
			if (Path.GetExtension(path) == ".xls")
			{
				OleDbcon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "; Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
			}
			else if (Path.GetExtension(path) == ".xlsx")
			{
				OleDbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
			}
			
			OleDbcon.Open();
			cmd.Connection = OleDbcon;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "SELECT * FROM [Sheet1$]";
			objAdapter1 = new OleDbDataAdapter(cmd);
			objAdapter1.Fill(ds);
			dtExcelData = ds.Tables[0];
			
			string consString = "Your Sql Connection string";
			
		    /* You want insert into your sql database table using SqlBulkCopy. */
			using (SqlConnection con = new SqlConnection(consString))
			{
				using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
				{
					//Set the database table name
					sqlBulkCopy.DestinationTableName = "SqlDatabase Table name where you want insert data";
					//[OPTIONAL]: Map the Excel columns with that of the database table
					sqlBulkCopy.ColumnMappings.Add(".xls/.xlsx Header column name(Id)", "Your database table column(IndexId)");
					.
					.
					.
					con.Open();
					sqlBulkCopy.WriteToServer(dtExcelData);
					con.Close();
				}
			}
			/* You want insert into your sql database table using SqlBulkCopy. */
		}
	}
	catch (Exception ex)
	{ }
