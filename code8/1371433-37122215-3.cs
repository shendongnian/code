    public double GetTotalScore(string regNo)
        {
            SqlConnection connection=new SqlConnection(ConnectionString);
    
            string query = "select sum(Score) from SaveResult where RegNo='" + regNo + "' group by RegNo";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            double total =  (double)cmd.ExecuteScalar();
            connection.Close();
            return total;
        } 
