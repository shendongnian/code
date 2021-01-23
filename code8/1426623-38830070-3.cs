    using (MyDbContext dbContext = new MyDbContext())
    {
        TinMan jebediah = dbContext.TinMen.FirstOrDefault(man => man.Id == 2);
        jebediah.HeartId = null;
        dbContext.SaveChanges();
    }
