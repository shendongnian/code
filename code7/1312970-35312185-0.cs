    List<Items> items = null;
    using(var dbContext = contextFactory.GetContext())
    { 
         items = dbContext.Items.ToList(); //query all the items
    }
    //now loop the items
    foreach(item in items )
    {
        try
        {
            var result = IRemoteWebService.SomeOperation(item);
        }
        catch(MyException e)
        {
            //assume that all possible exceptions are caught
        }
    }
    
