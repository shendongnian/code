     class UserRepository : IDisposable //using IDisposable to dispose db context
     {
          private AppDatabase _context;
          public UserRepository()
          {
               _context = new AppDatabase();
          }
   
          public ApplicationUser Find(string id)
          {
               return _context.Set<ApplicationUser>().Find(id);
          }
          public void Update(ApplicationUserentity entity)
          {
              _context.Entry(entity).State = EntityState.Modified;
              _context.SaveChanges();
          }
          public void Dispose()
          {
               _context.Dispose();
          }   
     }
