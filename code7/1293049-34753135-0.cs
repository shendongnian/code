    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using MySql.Data.Entity;
    
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyModel : DbContext
    {
        protected internal MyModel() : base("name=MyModel") { }
    
        public static MyModel Create()
        {
            var model = new MyModel();
            try
            {
                model.Database.ExecuteSqlCommand(
                    "SET SESSION sql_mode = 'PAD_CHAR_TO_FULL_LENGTH';");
            }
            catch
            {
                model.Dispose();
                throw;
            }
            return model;
        }
    
        // other MyModel members
    }
    
    public sealed class MyContextFactory : IDbContextFactory<MyModel>
    {
        MyModel IDbContextFactory<MyModel>.Create()
        {
            return new MyModel();
        }
    }
