    public static void UsingDBContext(Action<DBContext> action){
    try
        {
           using(var trans = new TransactionScope())
           {
              using(var context = new DBContext())
              {
                 action(context);
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
