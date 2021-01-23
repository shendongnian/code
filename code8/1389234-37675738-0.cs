	var results = dogowners.Select(x=> new Owner()                               
								{
									OwnerId = x.OwnerId, 
									DogsCount = x.Dogs.Count()
								})
							.Concat(catowners.Select(x=> new Owner() 
								{
									OwnerId = x.OwnerId, 
									CatsCount = x.Cats.Count()
								}))
							.GroupBy(x=> x.OwnerId)
							.Select(x=> new Owner() 
							{
								OwnerId = x.Key, 
								DogsCount = x.Sum(s=>s.DogsCount),  
								CatsCount = x.Sum(s=>s.CatsCount)
							}) 
							.ToList();		 
