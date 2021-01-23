    DateTime completeDate = DateTime.Now;
    using (SqlConnection connect = new SqlConnection(connectionString))
    {
        string updateQueryCompletedDate = @"UPDATE Conversions 
                                            SET CompletedDate = @CompleteDate,
                                            Status = 'Completed'
                                            WHERE ID = @ID"; 
    
        SqlCommand command1 = new SqlCommand(updateQueryCompletedDate, connect);
        command1.Parameters.AddWithValue("ID", item1.ID);
        command1.Parameters.AddWithValue("CompleteDate",completeDate);
    
        connect.Open();
        command1.ExecuteNonQuery();
        connect.Close();
    }
