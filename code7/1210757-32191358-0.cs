    private void SaveEntity()
    {
        using (var oContext = new MyEntities())
        {
            SaveEntityInfo(oContext);
            SaveOwners(oContext);
            SavePartners(oContext);
            SaveOfficers(oContext);
            SaveDirectors(oContext);
            oContext.SaveChanges();
        }
    }
    
    //One of multiple save methods
    private void SaveEntityInfo(MyEntities context)
    {
        //Add something to context
        //Remove something from context
        //Update something in context
        //But never use context.Save() here
        //Let SaveChanges() only calls in your SaveEntity() method
    }
