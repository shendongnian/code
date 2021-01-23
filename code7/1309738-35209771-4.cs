    public static async Task<int> SaveChangesAsync(this DbContext context, Audit audit, CancellationToken cancellationToken)
    {
    	audit.PreSaveChanges(context);
    	var rowAffecteds = await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    	audit.PostSaveChanges();
    
    	if (audit.CurrentOrDefaultConfiguration.AutoSavePreAction != null)
    	{
    		audit.CurrentOrDefaultConfiguration.AutoSavePreAction(context, audit);
    		await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    	}
    
    	return rowAffecteds;
    }
