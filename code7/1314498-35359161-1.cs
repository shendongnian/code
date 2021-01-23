    ISession sess = GetSession(true);
    foreach (MonType oe in pListobject)
    {
      try
      {
        sess.SaveOrUpdate(oe);
      }
      catch
      {
        Log("Object details", oe.details);//Add whatever details you want to log
        RollBackTransaction();
        throw; // dont throw ex
      }
    }
    CommitTransaction();
