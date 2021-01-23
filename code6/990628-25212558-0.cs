     string queryfill = "SELECT * From master where Number = @Number";
     DataTable table = new DataTable();
     using (OleDbConnection conn = new OleDbConnection(ConnString))
     using (OleDbDataAdapter da = new OleDbCommand(queryfill, conn))
     {
       da.SelectCommand.Parameters.AddWithValue("Number", Number.Text);
       da.Fill(table);
    }
