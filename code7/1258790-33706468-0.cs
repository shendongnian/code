    OpenFileDialog OpenCSVDialog = new OpenFileDialog();
                OpenCSVDialog.Filter = "Excel |*.xls";
                OpenCSVDialog.ShowDialog();
                ExcelFileName = System.IO.Path.GetFileName(OpenCSVDialog.FileName);
                string path = System.IO.Path.GetDirectoryName(OpenCSVDialog.FileName);
                fullpath = Path.Combine(path, ExcelFileName);
                dt_data = new DataSet("CSV File");
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
              "Data Source=" + fullpath +
              ";Extended Properties='Excel 8.0;'";
                using (var conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    string query = string.Format("select * from [{0}$]", "Sheet1");
                    using (var adapter = new OleDbDataAdapter(query, conn))
                    {
                        adapter.Fill(dt_data);
                    }
                }
