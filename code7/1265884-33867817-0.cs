    public UpdateClient(client)
    {
      try
      {
        TransactionScope scope0 = new TransactionScope();
        // some code
        scope0.Complete();
      }
      catch(Exception ex)
      {
        Logger.EnlistException(ex); // collect the exception
      }    
    }
    public void UpdateClients(clients)
    {
      try
      {
         TransactionScope scope1 = new TransactionScope();
         foreach (client c in clients)
         {
           UpdateClient(c);
         }
         scope1.Complete();
      }
      catch (Exception ex)
      {
          Logger.EnlistException(ex);           
      }
      Logger.WriteEnlistedExceptions();
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
