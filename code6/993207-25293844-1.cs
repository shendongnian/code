    if (reader.GetValue(0) != DBNull.Value)
    {
      var date =  reader.GetDateTime(0);
    }
    else {
    
      var date =  new DateTime(2000, 1, 1);
    }
