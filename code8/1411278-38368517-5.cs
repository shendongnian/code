    public interface IUnitOfWork
        {
            DbContext Database { get; }
    
            /// <summary>
            /// Saves changes to all objects that have changed within the unit of work.
            /// </summary>
            void SaveChanges();
        }
