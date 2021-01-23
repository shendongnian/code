    public void Create(List<ApplicationUserRole> item)
    {         
        using (var context = new MyContext())
        {  
            context.ApplicationUserRole.AddRange(data);
            context.SaveChanges();  
        }         
    }
