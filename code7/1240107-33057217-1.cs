    string tableName = textbox1.text;
    using(SqlConnection cnn = new SqlConnection(... connectionstring...))
    {
        cnn.Open();
        DataTable dt = cnn.GetSchema("TABLES");
        DataRow[] rows = dt.Select("TABLE_NAME = '" + tableName + "'");
        if(rows.Length > 0)
        {
            // Now you are sure to have a valid table in your textbox
            // and could use the input value without risking an Sql Injection
            string sql = "INSERT INTO [" + tableName + "] ([itemserial]," + 
                         "[itemname],[itemcount],[itemimage]) " + 
                         "VALUES(@itemserial,@itemname,@itemcount,@itemimage)";
            .... the remainder of your code that use the query above....
        }
        else
            MessageBox.Show("Please enter a valid name for your table");
