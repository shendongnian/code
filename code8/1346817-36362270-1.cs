    int count = 0;
    using (var con = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand("RunAStoredProc", con))
    {
       cmd.CommandType = CommandType.StoredProcedure;
       count = (int)cmd.ExecuteScalar();
    }
    Console.WriteLine(count);
    Console.ReadKey();
