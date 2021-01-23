     var query=rentdb.Invoices.Where(a => a.owner_id == getId).FirstOrDefault();
  
     var querylist = new List<Invoices> { query };
   
     rd.SetDataSource(querylist);
