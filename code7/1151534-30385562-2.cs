    protected IQueryable<RaceCar> GetRaceCars() 
    {
        IQueryable<RaceCar> myCollection = null;
        
        using (var entity = new MyEntities())
        {
            myCollection = entity.RaceCar.Where(w => w.Something == "something"); // This doesn't call the database yet
        }
        return myCollection;
    }
