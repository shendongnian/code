    public interface IUnitOfWork
    {
       Table<T> GetTable();
       void SubmitChanges();
    }
