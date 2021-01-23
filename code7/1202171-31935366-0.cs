    dRead = cmd.ExecuteReader();
    while (dRead.Read())
    {
        for (int j = 0; j < 3; j++)
          {
             ques[j] = dRead["q" + i].ToString();
          }              
    }
    dRead.Close();
    cmd.Dispose();
    dbConn.Close();
    return ques;
