    using(SqlDataReader dr = command.ExecuteReader()) 
    {
      if(dr.Read() && !dr.IsDbNull(5)) 
      {
        DateTime userExpiryDate = dr.GetDateTime(5);  
        if (userExpiryDate > DateTime.Today)
        {
          // Do something
        }
      }
    }
