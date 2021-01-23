     var depots = new List<Depot>
            {
                new Depot { DepotID = 1, Name = "Porana"},
                new Depot { DepotID = 2, Name = "Far North"},
    
    
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));// should be:
            depots.ForEach(s => context.Depots.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
