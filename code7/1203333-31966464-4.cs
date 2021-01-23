	var maximums = input.Split(new [] {'|'}, StringSplitOptions.RemoveEmptyEntries)
		.Aggregate((IEnumerable<int>)null,(m,r) => 
        {
			var cells = r.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c));
			return m == null ? cells : cells.Zip(m, Math.Max);
		});
