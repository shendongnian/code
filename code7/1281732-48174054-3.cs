    namespace CW.Repository.DBModel
    {
            
      public partial class CWEntities : DbContext
      {
          public CWEntities()
            : base("name=CWEntities")
          {
          }
    
          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
            throw new UnintentionalCodeFirstException();
          }
      ...
      ...
      }
    }
