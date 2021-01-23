    command.Connection = connection;
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "InsertBets";
    command.Parameters.Add("@FixtureId", SqlDbType.Int);
    // add the other paramters
    foreach (Bet bet in bets)
    {
        command.Parameters["@FixtureId"].Value = bet.FixtureId;
        // set the other parameters
        command.ExecuteNonQuery();
    }
