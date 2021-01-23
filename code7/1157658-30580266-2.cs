    var orders = datalist.GroupBy(o => o.ID)
                         .Select(g => new Order {
                               ID       = g.Key,
                               Output   = g.First().Output,
                               Wharf    = g.First().Wharf,
                               PartOf   = g.First().PartOf,
                               Product  = g.Select(o => o.Product).ToArray(),
                               Quantity = g.Select(o => o.Product).ToArray(),  
                               Storage  = g.Select(o => GetStorageArea(o.Product)).ToArray()
                             })
                         .ToList();
