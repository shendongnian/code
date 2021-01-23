    public interface IUnitofWork
    {
        void Rollback();
        void Save();
    }
    public class UnitOfWork
    { 
        EntitieFraneworkContext Context {get;set;}
       // other code ...
       public UnitOfWork()
       {
           Context = new EntitieFraneworkContext();
           Context.Database.BeginTransaction();
          //make sure you set a transaction when you init a new UoW
       }
       public void Save()
       {
          Context.Savechanges();
          Context.CommitTransaction();
       }
