    public List<data> GetComponentStatus()
    	{
    		List<data> d= null;
    		using(var entity=new FM())
    		{
    			var  d =  from a in entity.getdata()
    					  group a by a.customer into grp
    					  select new data {Cutomer= grp.Key ,Name = string.Join(",",grp.Select (g => g.Name))};
    				
    				return d.ToList(); 
    		}
    	
    	}
