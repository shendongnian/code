    var results = collection.AsQueryable()
       .Where(v => v.ProjectName.Equals("input")
       .SelectMan(v => v.VehicleEntries)
       .Where(i => i != null)
       .ToList();
