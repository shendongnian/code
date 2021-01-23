    public interface IUnitofWork
    {
        void Rollback();
        void Save();
    }
    public class UnitOfWork
    { 
            // other code ...
           public UnitOfWork()
           {
                Context = new EntitieFraneworkContext();
                Context. BeginTransaction();//make sure you set a transaction when you init a new UoW
            }
            public void Save()
           { 
                 Context.Savechanges();
                 Context.CommitTransaction();
            }
     }
