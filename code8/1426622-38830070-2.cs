    using (MyDbContext dbContext = new MyDbContext())
    {
        TinMan jebediah = dbContext.TinMen.FirstOrDefault(man => man.Id == 2);
        context.Entry(jebediah).Reference(t => t.Heart).Load();
        jebediah.Heart = null;
        dbContext.SaveChanges();
    }
