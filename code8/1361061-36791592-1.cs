    string exampleSQL = "SELECT * from mydatetable where dateOne = @date1 and dateTwo = @date2";
    SqlConnection connection = new SqlConnection(/* connection info */);
    SqlCommand command = new SqlCommand(sql, connection);
    
    command.Parameters.Add("@date1", SqlDbType.DateTime).Value = myDateTime;
    command.Parameters.Add("@date2", SqlDbType.DateTime).Value = rd2[1];
