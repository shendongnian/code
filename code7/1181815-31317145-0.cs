		//Your Method signature
		{
			//create connection string
            var connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +
                ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
            //process
            using (var conn = new OleDbConnection(connStr))
            {
                conn.Open();
                //programatically get the first sheet, whatever it is named.
                var sheetName = GetSheetNames(conn)[0].SheetNameOf;
                var adapter = new OleDbDataAdapter(String.Format("SELECT * FROM [{0}]", sheetName), connStr);
                var ds = new DataSet();
                adapter.Fill(ds, "anyNameHere");
                var data = ds.Tables["anyNameHere"];
                //copy and remove blank lines
                var resData = data.Clone();
                var filteredData = data.Rows.Cast<DataRow>().Where(
                    row => !row.ItemArray.All(
                        field => field is DBNull ||
                                 field == null ||
                                 (String.IsNullOrEmpty(field.ToString().Trim())))
                    );
                filteredData.CopyToDataTable(resData, LoadOption.OverwriteChanges);
                var newData = resData.AsEnumerable();
				//whatever you need to do
        }
		
		public List<SheetName> GetSheetNames(OleDbConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            DataTable excelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            var sheetNames = (from DataRow row in excelSchema.Rows
                              where !row["TABLE_NAME"].ToString().Contains("FilterDatabase")
                              select new SheetName { SheetNameOf = row["TABLE_NAME"].ToString() }
                              ).ToList();
            conn.Close();
            return sheetNames;
        }
