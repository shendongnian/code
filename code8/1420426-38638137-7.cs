    results.GroupBy(p => p.GroupName)
			.Select(g => new FinalModel
			{
				GroupName = g.Key,
				Properties = g.GroupBy(item => item.key)
							  .ToDictionary(innerGroup => innerGroup.Key, 
											innerGroup =>  innerGroup.Select(innerItem => innerItem.Value))
			});   
