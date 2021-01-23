    void updateBranch(Branches branch)
    {
        using (var dbContext = new entitiesContext())
        {
            dbContext.Branches.Attach(branch);                    
            dbContext.SaveChanges();
        }
    }
