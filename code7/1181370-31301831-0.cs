    public int Create(Company company)
    {
        using (MyDbcontextdbcontext context = new MyDbcontext()) 
        { 
            context.Entry(company).State = EntityState.Added; 
            context.SaveChanges(); 
        }
    }
