    public static IEnumerable<Rule> GetRules(Group group) 
    {
         if (group.SubGroups != null)
    	     return group.Rules.Concat(group.SubGroups.SelectMany(g => GetRules(g)));
    	 else
    		 return group.Rules;
    }
