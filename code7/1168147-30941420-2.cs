    String Example = "Example";
    var EDMXEntity = new List<String>();
    var Query = EDMXEntity.Entities.AsQueryable();
    var Result = Query
    	.Where(
    		x => 
    		(
                x.Name.ToString().ToLower().Contains(Example.ToLower())
    		))
    	.Take(50)
    	.ToList();
