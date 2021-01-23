    var properties = typeof(MyEntity).GetProperties().ToList();
    myEntities.GroupBy(x => x.numerator)
			.Select(x => new
			{
				Key = g.Key,
				Sums = properties.Select(p => new 
				{ 
				    Name = p.Name, 
				    Sum = g.Sum(entity => (int)p.GetValue(entity, null)) 
				}).ToList()
			}).ToList();
