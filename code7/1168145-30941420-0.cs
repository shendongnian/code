    String Example = "Example";
    var EDMXEntity = new List<String>();
    var Query = EDMXEntity.Entities.AsQueryable();
    var Result = Query
    	.Where(
    		x => 
    		(
               String.Equals(x.Name, Example, StringComparison.CurrentCultureIgnoreCase)
    		))
    	.Take(50)
    	.ToList();
