        ISession sess = GetSession(true);
        try
        {
            foreach (MonType oe in pListobject)
            {
                sess.SaveOrUpdate(oe);
            }
            CommitTransaction();
        }
        catch (DbUpdateException ex)
        {
            var entry = ex.Entries.Single(); //get the entity
            // do your stuff
        }
        catch (Exception ex)
        {
            try
            {
                RollBackTransaction();
            }
            catch
            {
            }
            throw ex;
        }
