    using (var ctx = new MyDbContext())
    {
        var person1 = new Person { Id = 1 };
        ctx.Persons.Add(person1);
        await ctx.SaveChangesAsync();
 
        await context.Database.ExecuteSqlCommandAsync(string.Format("DELETE FROM `PersonModels`"));
   
        // This is the secret
        ((IObjectContextAdapter)ctx).ObjectContext.Persons.Detach(person1);
        ctx.Persons.Add(person1)
        await ctx.SaveChangesAsync();
  
    }
