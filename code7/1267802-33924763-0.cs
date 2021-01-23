    private void somemethod()
    {
    string query = "SELECT * FROM [mssql_table_name] WHERE id=1";
    //I suppose you should have your datarow as id one. This helps a lot or where line="data in that"
    //whatever helps to find your row
    SqlConnection sqc = new SqlConnection(connection_string); // Defined by you
    sqc.Open();
    SqlCommand command = SqlCommand(query,sqc);
    SqlDataReader reader = command.ExecuteReader();
    this.footer.Text = GetDBString("line1", reader) + "\n" + GetDBString("line",reader)... etc;
