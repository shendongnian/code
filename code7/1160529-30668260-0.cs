    // check rules and perform actions
    // Get entire rulesets once into memory
    var ruleSets = OpcTagValueLogs.OpcTag.RuleSets.ToList(); 
    
    foreach (var log in logs.ToList()) // because items will be removed from the list during the loop, it is important to update the list on
    {                                  // each iteration, hence the .ToList()
    	
    	if (log.PriorValue != log.Value) // check to see if the prior value equals to new value
    	{                                // I am only interested in changing values, so delete the log entry
    		foreach (var ruleSet in ruleSets.Where(x => x.OpcTags.Logs.OpcTagValueLogs.OpcTagId == log.OpcTagId))
    		{
    			if (ruleSet.CheckRule(log.PriorValue, log.Value))
    			{
    				// perform action
    				// convert source timestamp to datetime
    				DateTime srcTS = new DateTime(1970, 1, 1).AddSeconds(log.SourceTimeStamp);
    				var action = ActionFactory.CreateAction(ruleSet.Action, log.PriorValue, log.Value, log.OpcTag, srcTS);
    				action.Execute();
    			}
    		}                      
    	}
    	
    	// The below was common to both the if and else condition, hence it is moved at the end of the conditional
    	// remove the entity
    	_context.OpcTagValueLogs.Remove(log);
    	logs.Remove(log);
    }
    
    // Call save changes once (less I/O)
    _context.SaveChanges();
