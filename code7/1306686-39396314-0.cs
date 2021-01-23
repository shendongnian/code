    public string UpdateParticipant(ParticipantUpdate Participant)
    {
        string ret = "";
        IsoDateTimeConverter dt = new IsoDateTimeConverter();
        dt.DateTimeFormat = "MM-dd-yyyy"; // we must have this format for our dates
        string json = JsonConvert.SerializeObject(Participant, dt);
        // Creating this output parameter is the key to getting the info back.
        var result = new OracleParameter
        {
            ParameterName = "RESULT",
            Direction = System.Data.ParameterDirection.InputOutput,
            Size = 100,
            OracleDbType = OracleDbType.Varchar2
        };
        // Now, setting the SQL like this using the result as the output parameter is what does the job.
        string sql = $@"DECLARE result varchar2(1000); BEGIN  @0 := WEBUSER.F_UpdateParticipant(@1); END;";
        var res = _db.db.Execute(sql, result, json);
    
        // Now return the value of the Output parameter!!
    
        ret = result.Value.ToString();
        return ret;
    }
