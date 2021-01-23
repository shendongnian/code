    string[][] arr = {{5, 10, 10, 10},{30, 20, 15, 16}};
    var arrayOutput = JsonConvert.SerializeObject(arr);
    try
    {
    string sql1 = "INSERT INTO tbt(img, fcth, dev) VALUES (ARRAY'" + arrayOutput + "')";
    dbcmd.CommandText = sql1;
    cmd.ExecuteNonQuery();
    }
    catch (NpgsqlException ex)
    {
    if (ex.Data == null)
    {
    throw;
    }
    else
    {
    }
    }
