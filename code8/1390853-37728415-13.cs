    public async Task<List<Rule>> GetRules(int instanceId, SharedRuleType ruleType, string searchTerm)
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
    		
     
    		// ToListAsync has been removed to make the example easier to understand
            return 	query.Select(x => new { Rule = x,
    								        Exclusions = x.Exclusions.Where(e => e.InstanceId == instanceId)
    					})
    			 .ToList()
    			 .Select(x => x.Rule)
    			 .ToList();
        }
    }
