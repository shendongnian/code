    [Flags]
    enum SupportedOperations {
        Read   = 1
    ,   Create = 2
    ,   Update = 4
    ,   Delete = 8
    }
    
    public abstract class GenericRepo<T> where T : class {
         public virtual SupportedOperations SupportedOps {
             get {
                 return 0; // Nothing is supported by default
             }
         }
         public virtual Task CreateAsync(T entity) {
             throw new NotSupportedException();
         }
         public virtual Task UpdateAsync(T entity) {
             throw new NotSupportedException();
         }
         public virtual Task DeleteAsync(T entity) {
             throw new NotSupportedException();
         }
    }
