    DbSet<Entity> dbSet = Context.dbSet;
    Entity ent = dbSet.Single(x => x.Id == id);
    Entity entityBeforeChange = dbSet.Single(x => x.Id == id); 
    Context.Entry(entityBeforeChange).State = EntityState.Detached; // severs the connection to the Context
    ent.FirstName = "New name";
    
    Context.SaveChanges();
