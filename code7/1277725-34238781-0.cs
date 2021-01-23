    private void BtnSelectFile_Click(object sender, EventArgs e)
        {
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
                            DataTable dt = new DataTable();
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
                //TODO
            }
    }
