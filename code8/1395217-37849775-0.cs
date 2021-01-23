    // ex -- Given following header
	List<string> headers = new List<string>();
	headers.Add("fo");
	headers.Add("fum");    
    DataTable dt; // Assign correct data source.
	var results =dt.AsEnumerable()
			.GroupBy(g=>g.Field<string>("fee"))       
			.Select(x=> new 
					{
						x.Key, 
						dict = headers.ToDictionary(h=>h, h=>x.Sum(s=>s.Field<int>(h)))
					})
			.ToList();  
