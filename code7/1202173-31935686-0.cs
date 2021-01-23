    public List<string> loadSecretQues(string email)
    {
        List<string> ques=new List<string>();
    
        dbConn = new OdbcConnection(dbConnString);
        dbConn.Open();
        cmd = new OdbcCommand();
        cmd.Connection = dbConn;
    
        cmd = new OdbcCommand("SELECT q1, q2, q3 FROM Information WHERE EmailAdd = '" + email + "'", dbConn);
        dRead = cmd.ExecuteReader();
    
     if (dRead.HasRows)
      {
        while (dRead.Read())
        {
          ques.Add(dRead["yourColumnName"].ToString());
        }
      }
    return ques;
    }
