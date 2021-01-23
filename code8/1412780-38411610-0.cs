    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand cmdClassroom= new SqlCommand("insert into YourTable(Facility,Rank)Values(@facility,@rank)", connection))
        {
           cmdClassroom.Parameters.AddWithValue(@facility,"Classroom");
           cmdClassroom.Parameters.AddWithValue(@rank,rbclassrooms.SelectedValue);
        }
    //Similarly for next facilities
        using (SqlCommand command2 = new SqlCommand(commandText2, connection))
        {
        }
        // etc
    }
