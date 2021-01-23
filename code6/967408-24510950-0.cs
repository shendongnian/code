     public static bool dataMatch(string data, string tableName, string column)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(CnnStr);//connection string has been applied to CnnStr
    
    
            cmd.CommandText = "SELECT * FROM '"+tableName+"' WHERE [@column]=[@data]";
            cmd.Parameters.AddWithValue("@column", (column as Object).ToString());
            cmd.Parameters.AddWithValue("@data", (data as Object).ToString());
    
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                cmd.Connection.Close();
                return true;
            }
            dr.Close();
            cmd.Connection.Close();
            return false;
        }
