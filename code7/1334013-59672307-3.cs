    public static void Update<T,K>(DbContext context, T t) where T:EntityBase<K>
    {
        DbSet<T> set = context.Set<T>();
        if(set==null) return;
        if(context.Entry<T>(t).State == EntityState.Detached)
        {
             try
             {
                 T attached = set.Attached(t);
                 context.Entry<T>(attached).State = EntityState.Modified;
             }catch(Exception ex)
             {
                 T found = set.Find(t.PrimaryKey);
                 context.Entry(found).CurrentValues.SetValues(t);
             }
         }
         context.SaveChanges();
    }
    
