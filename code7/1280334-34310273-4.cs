    myEntities.GroupBy(x => x.numerator)
			.Select(x => new
			{
				Key = g.Key,
				Sums = typeof(MyEntity).GetProperties().Select(p => new 
				{ 
				    Name = p.Name, 
				    Sum = g.Sum(entity => (int)p.GetValue(entity, null)) 
				}).ToList()
			}).ToList();
