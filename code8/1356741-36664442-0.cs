    var matchingrow = ds.Tables[0].AsEnumerable()
                                  .FirstOrDefault(table=> table.Field<Int16>("Pwd") == Convert.ToInt16(pwd) 
                                                       || table.Field<string>("Email") == email);
    
    if(matchingrow != null)
    {
        // matching email/pwd. logic goes here
       
        // matchingrow.Field<string>("Email");
    }
