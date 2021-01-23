    public void sqlUpdqte(string tableName, string columnName, string value, string whereClause){
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "("+columnName+") values (@value)" + (whereClause != null && whereClause != string.Empty ? "where " + whereClause : ""),con);
        cmd.Parameters.AddWithValue("value",value);
        cmd.ExecuteNonQuery();
        con.Close();
    }
