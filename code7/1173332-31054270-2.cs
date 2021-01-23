    class MyRepository
    {
       public MyRepository(IDbSet<MyType> dbSet) 
       {
         this.dbSet = dbSet;
       }
    
       MyType FindEntity(int id)
       {
         return this.dbSet.Find(id);
       }
    }
