    public void sqlInsert(string tableName, string columnName, string value){
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "("+columnName+") values (@value)"),con);
        cmd.Parameters.AddWithValue("value",value);
        cmd.ExecuteNonQuery();
        con.Close();
    }
