    ctx.Configuration.AutoDetectChangesEnabled = false;
    foreach(var item in Doc)
    {
    	// ...code...
    }
    
    ctx.Configuration.AutoDetectChangesEnabled = true;
    ctx.SaveChanges();
