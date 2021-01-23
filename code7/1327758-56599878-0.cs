    if (context.Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
    {
    	context.Database.EnsureCreated();
    }
    else
    {
    	context.Database.Migrate();
    }
