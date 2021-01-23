    if(sqlDataReader.IsDBNull(0))
    {
       // deal with null
    }
    else  
    {
      var id = sqlDataReader.GetInt32(0);
    }
