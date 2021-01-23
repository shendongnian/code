    public void updateOneRow(string tableName, string columnName, string value){        
        con.Open();
        query = "SELECT count ("+columnName+") FROM "+tableName;
        SqlCommand cmd = New SqlCommand(query, con);
        Int32 count = (Int32)cmd.ExecuteScalar();
        if(count == 0){
            cmd = new SqlCommand("INSERT INTO " + tableName + "("+columnName+") values (@value)"),con);
        }
        else{
            query = "SELECT top 1 "+columnName+" FROM "+tableName;
            cmd = New SqlCommand(query, con);
            string dbValue = (string)cmd.ExecuteScalar();
            if (dbValue != null && dbValue != string.Empty)
                value += ";"+dbValue;
            cmd = new SqlCommand("UPDATE  " + tableName + " set ["+columnName+"] = @value", con);
        }
        cmd.Parameters.AddWithValue("value",value);
        cmd.ExecuteNonQuery();
        con.Close();
    }
