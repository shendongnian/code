    var internalContext = context.GetType().GetProperty("InternalContext", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(db);
    var providerName = (string)internalContext.GetType().GetProperty("ProviderName").GetValue(internalContext);
    var conf = new Workshop.Migrations.Configuration();
    conf.TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo(connectionString, providerName);
 
