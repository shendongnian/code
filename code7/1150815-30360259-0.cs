    var uniqueCountryCustomer = 
        invoicesDataTable
        .AsEnumerable()
        .GroupBy(key => new
        {
            Department = (string)row["Department"], 
            Attorney = (string)row["MatterNumber"], 
            MatterNo = (string)row["CUSTOMERNAME"]
        },vals => new {
            something = ...,
            something = ...
        });
    
    foreach(var customer in uniqueCountryCustomer)
    {
      var key = val.Key;
    
      foreach(var vals in customer)
      {
         ... Do stuff ...
      }
    }
