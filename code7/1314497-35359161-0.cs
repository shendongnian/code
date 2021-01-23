        ISession sess = GetSession(true);
        try
        {
            foreach (MonType oe in pListobject)
            {
              try
              {
                sess.SaveOrUpdate(oe);
              }
              catch
              {
                Log("Object details", oe.details);//Add whatever details you want to log
                throw
              }
            }
            CommitTransaction();
        }
        catch (Exception ex)
        {
            RollBackTransaction();
            throw; // dont throw ex
        }
