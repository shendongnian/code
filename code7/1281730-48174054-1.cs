    namespace CW.Repository.DBModel
    {
        public partial class CWEntities : DbContext
        {
            public CWEntities(string ConnectionString)
                : base(ConnectionString)
            {
            }        
        }
    }
