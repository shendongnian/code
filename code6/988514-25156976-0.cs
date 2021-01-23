    public void GiveMeAProperName(Action<DBContext> databaseAction)
    {
        try
        {
           using(var trans = new TransactionScope())
           {
              using(var context = new DBContext())
              {
                 . . . // method body
              }
              trans.Complete();
           }
        }
        catch(Exception ex)
        {
           Log.Error(ex.Message);
           if (ex.InnerException != null)
              Log.Error(ex.InnerException.Message);
        }
    }
