    try
    {
        using(SqlConnection connect = new SqlConnection(....))
        using(SqlCommand command = new SqlCommand(
            @"SELECT FILE_DATE_PROCESSED, FILE_NAME FROM FILE_DATE_PROCESSED", connect))
        {
            connect.Open();
            using(SqlDataReader reader = command.ExecuteReader())
            {
               while (reader.Read())
               {
                     Console.WriteLine(reader["FILE_DATE_PROCESSED"].ToString());
                     Console.WriteLine(reader["DATE_ENTERED"].ToString());
               }
            }
       }
    }
    catch (Exception e)
    {
       Console.WriteLine(e.ToString());
    }
