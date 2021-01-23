    internal UpdateClient(client)
    {
    try
      {
        // some code
      }
      catch(Exception ex)
      {
        Logger.EnlistException(ex); // collect the exception
      }
    }
    
    public UpdateClient(client)
    {
      try
      {
        TransactionScope scope0 = new TransactionScope();
    
        //call internal UpdateClient
        /*internal*/ UpdateClient(client);
    
        scope0.Complete();
      }
      catch(Exception ex)
      {
        Logger.WriteEnlistedExceptions(ex); // collect and write the exception
      }     
    }
    
    public void UpdateClients(clients)
    {
      try
      {
         TransactionScope scope1 = new TransactionScope();
         foreach (client c in clients)
         {
           /*interanl*/ UpdateClient(c);
         }
         scope1.Complete();
      }
      catch (Exception ex)
      {
          Logger.WriteEnlistedExceptions(ex);           
      }
    }
    
    public partial class Logger
    {
      private static List<Exception> _exceptionList = new List<Exception>();
      public static void EnlistException(Exception ex)
      {
        _exceptionList.Add(ex);
      }
      public static void WriteEnlistedExceptions()
      {
        foreach(Exception ex in _exceptionList)
          LogException(ex);
        _exceptionList.Clear();
      }
    }
