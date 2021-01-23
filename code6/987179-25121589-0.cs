	var l = new List<Tuple<int, string, string>>();
	
	l.Add(Tuple.Create(1, "Apple", "Red Delicious"));
	l.Add(Tuple.Create(1, "Apple", "Green"));
	l.Add(Tuple.Create(1, "Apple", "Granny"));
	l.Add(Tuple.Create(2, "Tomato", "Roma"));
	l.Add(Tuple.Create(2, "Tomato", "Cherry"));
	
	var res = l.GroupBy(t => t.Item2).Select(g => new { Id = g.First().Item1, Text = g.Key, Description = string.Join(", ", g.Select(i => i.Item3)) });
	res.Dump(); // Linqpad output
