    Umfrage Survey = await db.Umfragen.FindAsync(SurveyId);          
    SqlCommand Command = new SqlCommand("UpdateSurvey", ConnectionString);
    Command.CommandType = CommandType.StoredProcedure;                   
    using (ConnectionString)
    {
        ConnectionString.Open();
        Command.ExecuteNonQuery();
        await db.Entry(Survey).ReloadAsync();  
        return Ok(Survey);                                    
    }
