    public async Task<List<Rule>> GetRules(int instanceId, SharedRuleType ruleType, string searchTerm)
	{
		using ( var context = new MyDbContext() )
		{
			var query = context.Set<Rule>()
				.Include( r => r.Exclusions ) // *** Currently returns ALL exclusions but I only want ones where InstanceId == instanceId(param) ***
				.Where( r => r.IsActive )
				.Where(r => r.Exclusions.Any(t => t.InstanceId == instanceId));
			if ( !string.IsNullOrEmpty( searchTerm ) )
			{
				query = query.Where( r => r.RuleValue.Contains( searchTerm ) );
			}
			if ( ruleType != SharedRuleType.None )
			{
				query = query.Where( r => r.RuleType == ruleType );
			}
			return await query.ToListAsync();
		}
	}
