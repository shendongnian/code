    void updateBranch(Branches branch)
    {
        using (var dbContext = new entitiesContext())
        {
            dbContext.Branches.Attach(b => b.num == branch.num);                    
            dbContext.SaveChanges();
        }
    }
