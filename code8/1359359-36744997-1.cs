    private static void PrepareCommand(SqlCommand command, Teacher teacher)
    {
        if(string.IsNullOrEmpty(teacher.ID))
            command.Parameters.AddWithValue("@ID", teacher.ID);
        command.Parameters.AddWithValue("@name", teacher.Name);
        command.Parameters.AddWithValue("@surname", teacher.Surname);
        if(string.IsNullOrEmpty(teacher.Email))        
            command.Parameters.AddWithValue("@email", teacher.Email);
        command.Parameters.AddWithValue("@phone", teacher.Phone);
    }
