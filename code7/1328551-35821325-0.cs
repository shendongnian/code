    var connecitonString = "user id=username;" +
                                           "password=password;server=serverurl;" +
                                           "Trusted_Connection=yes;" +
                                           "database=database; " +
                                           "connection timeout=30";
        
    using (SqlConnection myConnection = new SqlConnection(connecitonString))
    {
      myConnection.Open();
      //Use connection here
    }
