    public void SaveToDB(BestuurModel model)
    {
        // Do validation etc.
        db.persoon.Add(model); 
        db.persoon.SaveChanges(); 
    }
