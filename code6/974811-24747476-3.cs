    using (var conn = new OleDbConnection(.......))
    {
        conn.Open();
        // make two commands here
        var commInsert = new OleDbCommand(.....);
        var commUpdate = new OleDbCommand(.....);
        // here add your parameters with no value
        commInsert.Parameters.Add(new OleDbParameter(....));
        .......
 
        Foreach (....)
        {
            Foreach (....)
            {
                // here only reset the values
                commUpdate.Parameters[0].Value = ...
                ...
                int recs = commUpdate.ExecuteNonQuery();
                if (recs < 1) // when no records updated do insert
                {
                    commInsert.Parameters[0].Value = iq_question;
                    .....
                }
            }
        }
        commInsert.Dispose();
        commUpdate.Dispose();
    }
