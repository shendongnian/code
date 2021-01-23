    Public class DbHelper
    {
        public static TenantDBEntities GetDbContext(string tenantName)
        {
            var connectionStringTemplate =
                @"metadata=res://*/Models.TenantDB.csdl|res://*/Models.TenantDB.ssdl|res://*/Models.TenantDB.msl;" +
                @"provider=System.Data.SqlClient;" +
                @"provider connection string=""data source=(localdb)\v11.0;" +
                @"initial catalog={0};"+
                @"user id={1};password={2};" +
                @"MultipleActiveResultSets=True;App=EntityFramework"";";
            
            var TenandDBName = "Database Name Based on Tenant";
            var TenantUserName = "UserName Based on Tenant";
            var TenantPassword = "Password Based on Tenant";
            var connectionString = string.Format(connectionStringTemplate, TenandDBName, TenantUserName, TenantPassword);
            var db = new TenantDBEntities(connectionString);
            db.Database.CreateIfNotExists();
        
            return db;
        }
    }
