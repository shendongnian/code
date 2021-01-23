    public class EntityContext : DbContext
    {
        public static EntityContext EntityStatic()
        {
        var entityCnxStringBuilder = new EntityConnectionStringBuilder("");
        var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);
            sqlCnxStringBuilder.DataSource = "DataSource";
            sqlCnxStringBuilder.UserID = "User";
            sqlCnxStringBuilder.Password = "Password";
            sqlCnxStringBuilder.InitialCatalog = "DatabaseName";
            sqlCnxStringBuilder.ConnectTimeout = 10;
            sqlCnxStringBuilder.Enlist = false;
            sqlCnxStringBuilder.Pooling = false;
            sqlCnxStringBuilder.AsynchronousProcessing = true;
            sqlCnxStringBuilder.TrustServerCertificate = true;
            sqlCnxStringBuilder.Encrypt = true;
            conn = sqlCnxStringBuilder.ConnectionString;
            //For reference
            //string conn = "Data Source=localhost;Initial Catalog=;User ID=root;Password=1234;";
            return new EntityContext(conn);
        }
        public EntityContext(string conn) : base(conn)
        {    
           
        }
    }
