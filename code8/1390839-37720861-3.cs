    public class RuleModel
	{
		public Rule Rule { get; set; }
		public IEnumerable<Exclusion> Exclusions { get; set; }
	}	
	
	public async Task<List<RuleModel>> GetRules(int instanceId, SharedRuleType ruleType, string searchTerm)
	{
		using ( var context = new MyDbContext() )
		{
			var query = context.Set<Rule>()
				.Where( r => r.IsActive );
	
			if ( !string.IsNullOrEmpty( searchTerm ) )
			{
				query = query.Where( r => r.RuleValue.Contains( searchTerm ) );
			}
	
			if ( ruleType != SharedRuleType.None )
			{
				query = query.Where( r => r.RuleType == ruleType );
			}
			
			// That statement do LEFT JOIN like:
			// FROM  Rules
			// LEFT OUTER JOIN Exclusions ON ([Rules].[Id] = [Exclusions].[RuleId]) AND ([Exclusions].[InstanceId] = @instanceId)
			var ruleExclusionQuery = query.Select(rule => new RuleModel { Rule = rule, Exclusions = rule.Exclusions.Where(e => e.InstanceId == instanceId) });
			var ruleList = await ruleExclusionQuery.ToListAsync();
		}
	}
