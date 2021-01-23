    Public class DbHelper
    {
        public static TenantDBEntities GetDbContext(string tenantName)
        {
            var connectionStringTemplate =
                @"metadata=res://*/Models.TenantDB.csdl|res://*/Models.TenantDB.ssdl|res://*/Models.TenantDB.msl;" +
                @"provider=System.Data.SqlClient;" +
                @"provider connection string=""data source=(localdb)\v11.0;" +
                @"initial catalog={0};"+
                @"integrated security=True;" +
                @"MultipleActiveResultSets=True;App=EntityFramework"";";
            
            var TenandDBName = "TenantDB_" + tenantName;
            var connectionString = string.Format(connectionStringTemplate, TenandDBName);
            var db = new TenantDBEntities(connectionString);
            db.Database.CreateIfNotExists();
        
            return db;
        }
    }
