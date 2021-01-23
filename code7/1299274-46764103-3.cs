    string excelFilePath = String.Empty;
    string stringConnection = String.Empty;
    
    using (OpenFileDialog openExcelDialog = new OpenFileDialog())
    {
    	openExcelDialog.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
    	openExcelDialog.FilterIndex = 1;
    	openExcelDialog.RestoreDirectory = true;
    	DialogResult windowsResult = openExcelDialog.ShowDialog();
    	if (windowsResult != System.Windows.Forms.DialogResult.OK)
    	{
    		return;
    	}
    
    	excelFilePath = openExcelDialog.FileName;
    	using (DataTable dt = new DataTable())
    	{
    		try
    		{
    			if (!excelFilePath.Equals(String.Empty))
    			{
    				stringConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties='Excel 8.0; HDR=YES;';";
    				using (OleDbConnection conn = new OleDbConnection(stringConnection))
    				{
    					conn.Open();
    					OleDbCommand cmd = new OleDbCommand();
    					cmd.Connection = conn;
    
    					DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
    					string sheetName = getFirstVisibileSheet(dtSheet);
    
    					cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
    					dt.TableName = sheetName;
    
    					OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    					da.Fill(dt);
    
    					cmd = null;
    					conn.Close();
    				}
    			}
    
    			//Read and Use my DT
    			foreach (DataRow row in dt.Rows)
    			{
    				//On my case I need data on first and second Columns
    				if ((row.ItemArray.Count() < 2) ||
    					(row[0] == null || String.IsNullOrWhiteSpace(row[0].ToString()))
    					||
    					(row[1] == null ||String.IsNullOrWhiteSpace(row[1].ToString())))
    				{
    					continue;
    				}
    
    				//Get the number from the first COL
    				int colOneNumber = 0;
    				Int32.TryParse(row[0].ToString(), out colOneNumber);
    				
    				//Get the string from the second COL
    				string colTwoString = row[1].ToString();
    				
    				//Get the string from third COL if is a file path valid
    				string colThree = (row.ItemArray.Count() >= 3 
    								&& !row.IsNull(2) 
    								&& !String.IsNullOrWhiteSpace(row[2].ToString()) 
    								&& File.Exists(row[2].ToString())
    								) ? row[2].ToString() : String.Empty;
    			}
    		}
    		catch (Exception ex)
    		{
    			MessageBox.Show("Import error.\n" + ex.Message, "::ERROR::", MessageBoxButtons.OK, MessageBoxIcon.Error);
    		}
    	}
    }
    
    private string getFirstVisibileSheet(DataTable dtSheet, int index = 0)
    {
        string sheetName = String.Empty;
        if (dtSheet.Rows.Count >= (index + 1))
        {
            sheetName = dtSheet.Rows[index]["TABLE_NAME"].ToString();
            if (sheetName.Contains("FilterDatabase"))
            {
                return getFirstVisibileSheet(dtSheet, ++index);
            }
        }
        return sheetName;
    }
