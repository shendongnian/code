	string input = "1234567890ABCDEF";
	/*
		1234
		5678
		90AB
		CDEF
	*/	
			
	int width = (int)Math.Sqrt(input.Length);
	
	var seq = input.AsEnumerable()
					.Select((c, i) => new {Chr = c, Row = i / width, Col = i % width})
					.OrderBy(a => a.Col)
					.ThenByDescending(a => a.Row)
					.Select(a=>a.Chr);
	var s = string.Join("", seq);
	Console.WriteLine(s);
