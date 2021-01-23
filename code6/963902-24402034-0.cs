    using (var connection = new SqlConnection(RConnString)) 
    {
        connection.Open();
        foreach (var batch in strSpScript.Split(new string[] {"\nGO", "\ngo"}, StringSplitOptions.RemoveEmptyEntries))
        {
             try
             {
                 new SqlCommand(batch, connection).ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 throw;
             }
        }
    }
