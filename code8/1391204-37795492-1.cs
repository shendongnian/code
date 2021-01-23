    public void DeleteUserSession(Guid id)
    {
        using(NHSession.BeginTransaction())
        {
          var instance = NHSession.Get(typeof(UserSession), id);
          if (instance != null)
          {
            NHSession.Delete(instance);
          }
          NHSession.Transaction.Commit();
        }
    }
