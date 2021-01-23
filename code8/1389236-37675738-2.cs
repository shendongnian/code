		Dictionary<int, Owner> owners = new Dictionary<int, Owner>();
		foreach(var dg in dogowners)
		{
			
			if(owners.ContainsKey(dg.OwnerId))
			{
				owners[dg.OwnerId].DogsCount += dg.Dogs.Count();
			}
			else 
			{
				owners.Add(dg.OwnerId, new Owner() 
				{
					OwnerId = dg.OwnerId, 
					DogsCount = dg.Dogs.Count()
				});
			}			
		}
		foreach(var ct in catowners)
		{
			if(owners.ContainsKey(ct.OwnerId))
			{
				owners[ct.OwnerId].CatsCount += ct.Cats.Count();
			}
			else 
			{
				owners.Add(ct.OwnerId, new Owner() 
				{
					OwnerId = ct.OwnerId, 
					CatsCount = ct.Cats.Count()
				});
			}			
		}
