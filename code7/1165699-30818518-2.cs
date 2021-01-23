    void updateBranch(Branches branch)
    {
        using (var dbContext = new entitiesContext())
        {
            dbContext.Branches.Attach(branch);
            dbContext.Entry(branch).State = EntityState.Modified;              
            dbContext.SaveChanges();
        }
    }
