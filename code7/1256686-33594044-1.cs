    // Note I've added a generic type parameter to define what kind of
    // objects will handle the whole unit of work
    public interface IUnitOfWork<TObject>
    {
         void RegisterNew(TObject some);
         void RegisterUpdated(TObject some);
         void RegisterDeleted(TObject some);
         void Commit();
         void Rollback();
    }
