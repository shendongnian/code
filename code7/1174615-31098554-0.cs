    var baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    production_cycles = from p in db.ProductionCycles
    	where p.IsRunning == true
    	select new Rest.ProductionCycle
    	{
    		id = p.ID,
    		name = p.Name,
    		created = p.Created,
    		steps = from s in p.Logs
    			where user_permissions.Contains(s.Permission.ID)
    			orderby s.ID ascending
    			select new Rest.Step
    			{
    				created = s.Created,
    				created_label = SqlFunctions.DateDiff("ss", baseDate, s.Created)
    				
    				////// the rest as usual
    				
    			},
    	};
