    public static void SaveCombiners()
    {
    	using (var db = new IP_dbEntities())
    	{
    		db.COMBINERs.RemoveRange(db.COMBINERs);
    		
    		List<COMBINER> list = new List<COMBINER>();
    		
    		foreach (var type1 in EventTypesList)
    		{
    			foreach (var type2 in EventTypesList)
    			{
    				list.Add(new COMBINER()
    				{
    					EVENTS_TYPE = db.EVENTS_TYPE.Single(type => type.event_type == type1),
    					EVENTS_TYPE1 = db.EVENTS_TYPE.Single(type => type.event_type == type2),
    					combine_status = _eventTypesCombinerCollection[type1][type2].Value == true ? "+" : "-"
    				});
    			}
    		}
    		
    		db.COMBINERs.AddRange(list);
    		db.SaveChanges();
    	}
    }
