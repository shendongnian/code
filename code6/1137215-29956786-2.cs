    using (ITransaction txn = DataManager.NewTransaction())
    {
        try
        {
            txn.Lock(proj);
            Collection col2 = proj.CreateCollection("Collection"); 
            txn.Commit();
        }
        catch (Exception e)
        {
            PetrelLogger.InfoOutputWindow(e.Message);
            throw;
        }
    }
    using (ITransaction txn = DataManager.NewTransaction())
    {
        try
        {
            txn.Lock(seismicProj);
            SeismicCollection seisColl = seismicProj.CreateSeismicCollection("NewSeismicCollection");
            txn.Commit();
        }
        catch (Exception e)
        {
            PetrelLogger.InfoOutputWindow(e.Message);
            throw;
        }
    }
