    public class MyContext : ObjectContext, IObjectContext
        {
            public event EventHandler ContextSaved;
    
            public void SaveChanges()
            {
                base.SaveChanges();
                if (ContextSaved != null)
                    ContextSaved.Invoke(this, null);
            }
    
            public void Dispose()
            {
                base.Dispose();
            }
    
            public IRepository<T> GetRepository<T>() where T : class
            {
                throw new NotImplementedException();
            }
        }
