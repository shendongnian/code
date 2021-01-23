            OleDbCommand cmd = new OleDbCommand(); ;
            OleDbDataAdapter oleda = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            UserBase loginUser = (UserBase)Session["LoggedUser"];
            SearchFilter filter = new SearchFilter();
            string action = "ExportDocumentType";
            filter.DocumentTypeID = Convert.ToInt32(cmbDocumentType.SelectedValue);
            filter.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
            try
            {
                Logger.Trace("Started Extracting Soft Data", Session["LoggedUserId"].ToString());
                // need to pass relative path after deploying on server
                oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                filePath + ";Extended Properties='Excel 12.0;';");
                try
                {
                    oledbConn.Open();
                }
                catch
                {
                    string con = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;HDR=Yes;IMEX=1";
                    oledbConn = new OleDbConnection(con);
                    oledbConn.Open();
                }
                // Get the data table containg the schema guid.
                dt = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    throw new Exception(" No sheets available!");
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
                cmd.Connection = oledbConn;
                cmd.CommandType = CommandType.Text;
                // Get column names of selected document type
                string SelectCommand = getIndexFieldsList();
                SelectCommand = "SELECT " + SelectCommand + " FROM [" + excelSheets[0] + "]";
                cmd.CommandText = SelectCommand;
                oleda = new OleDbDataAdapter(cmd);
                try
                {
                    oleda.Fill(ds);
                }
                catch
                {
                    throw new Exception("Selected file is not matching to " + cmbDocumentType.SelectedItem.Text + ".");//Bug Wrtier DMS ENHSMT 1-1012 M
                }
                string strXml = string.Empty;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                   // note: Do ur code here.. i prefer to create a insert satement from here using looping it out
                }
                else
                {
                    throw new Exception(" No data available in uploaded file!");//Bug Wrtier DMS ENHSMT 1-1012 M
                }
            }
            catch (Exception ex)
            {
                Logger.Trace("Exception:" + ex.Message, Session["LoggedUserId"].ToString());
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                // Clean up.
                if (oledbConn != null)
                {
                    oledbConn.Close();
                    oledbConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }
