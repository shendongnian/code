		var cache = new Dictionary<int,Dictionary<int,int>>();
		foreach(var item in sampleData)
		{
			if(!cache.ContainsKey(item.AccessGroupId))
			{
				cache[item.AccessGroupId] = new Dictionary<int,int>();
			}
		
			if(!cache[item.AccessGroupId].ContainsKey(item.DocumentId))
			{
				cache[item.AccessGroupId][item.DocumentId]=0;
			}
		
			cache[item.AccessGroupId][item.DocumentId]++;
		}
		
		
		var results = cache
					  .Select(a=>new{ 
								AccessGroupId = a.Key, 
								Values = a.Value.OrderByDescending(b=>b.Value)
										.Select(b=>new{ DocumentId = b.Key, Count = b.Value })
									    .Take(3)
					  });
