	var result = items.GroupBy(item => item.Name)
			          .Select(g => g.Aggregate((i, j) =>
			          {
				          i.SubItems.AddRange(j.SubItems);
				          return i;
			          }))
				      .ToDictionary(k => k.Name, v => v.SubItems);
