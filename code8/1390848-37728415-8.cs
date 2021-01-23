    public async Task<List<Rule>> GetRules(int instanceId, SharedRuleType ruleType, string searchTerm)
    {
        using ( var context = new MyDbContext() )
        {
            var query = context.Set<Rule>()
                .IncludeFilter( r => r.Exclusions.Where(x => x.InstanceId == instanceId))
                .Where( r => r.IsActive );
    			
    		// ... code ...
