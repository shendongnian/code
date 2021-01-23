    if (!conn.State.Equals(ConnectionState.Open))
        conn.Open();
    
    Console.WriteLine(conn.State.ToString());
    MySqlCommand cmd = new MySqlCommand("UPDATE tst SET col1 = 'Test' WHERE id = 5", conn);
    try
    {
        cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(conn.State.ToString());
    }
