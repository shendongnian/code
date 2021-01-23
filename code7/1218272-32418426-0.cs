        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection Conn;
            Conn = new System.Data.OleDb.OleDbConnection(
            "provider=Microsoft.Ace.OLEDB.12.0;Data Source='C:\\MyFile.xlsx';Extended Properties=Excel 12.0 XML;");
            var dt = new DataTable();
            string query = string.Format("SELECT  * FROM [{0}]", "Sheet1$");
            Conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, Conn);
            adapter.Fill(dt);
            MessageBox.Show(dt.Rows[0][0].ToString());
        }
