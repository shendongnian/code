    public string GetTotalScore(string regNo)
        {
            SqlConnection connection=new SqlConnection(ConnectionString);
            string query = "select sum(Score) from SaveResult where RegNo='"+regNo+"' group by RegNo";
            SqlCommand command = new SqlCommand(query, connection);  
            connection.Open();
            object total = command.ExecuteScalar();
            connection.Close();
            return Convert.ToString(total);
        }    
    }
