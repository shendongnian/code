    private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            DataTable dt;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel files | *.xls";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filePath = dlg.FileName;
                string extension = Path.GetExtension(filePath);
                string conStr, sheetName;
                conStr = string.Empty;
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath);
                        break;
                    case ".xlsx": //Excel 07 to later
                        conStr = string.Format(Excel07ConString, filePath);
                        break;
                }
                //Read Data from the Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            dt = new DataTable();
                            cmd.CommandText = "SELECT * From [Sheet1$]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();
                        }
                    }
                }
                //Save the datatable to Database
                string sqlConnectionString = MyConString;
                if(dt != null)
                {                
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                {
                    bulkCopy.ColumnMappings.Add("[userid]", "userid");
                    bulkCopy.ColumnMappings.Add("password", "password");
                    bulkCopy.ColumnMappings.Add("first_name", "first_name");
                    bulkCopy.ColumnMappings.Add("last_name", "last_name");
                    bulkCopy.ColumnMappings.Add("user_group", "user_group");
                    bulkCopy.DestinationTableName = "aster_users";
                    bulkCopy.WriteToServer(dt);
                    MessageBox.Show("Upload Successfull!");
                }
                }
            }
    }
