    public interface IUnitofWork
    {
        void Rollback();
        void Save();
    }
    public class UnitOfWork
    { 
        EntitieFraneworkContext Context {get;set;}
        DbContextTransaction Transaction{get;set;}
       // other code ...
       public UnitOfWork()
       {
           Context = new EntitieFraneworkContext();
           Transaction=Context.Database.BeginTransaction();
          //make sure you set a transaction when you init a new UoW
       }
       public void Save()
       {
          Context.Savechanges();
          Transaction.CommitTransaction();
          //some code to re-init transation might be needed
       }
       public void Rollback()
       {
          Transaction.Rollback();
         //some code to re-init transation might be needed
       }
