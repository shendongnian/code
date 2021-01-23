    var pricingDetailExtendeds = new[]
            {
                new
                {
                    PricingID = 1,
                    Name = "abc",
                    Age = 56,
                    Group = "P1"
                },
                new
                {
                    PricingID = 1,
                    Name = "abc",
                    Age = 56,
                    Group = "P2"
                }
            };
            var pricngtemp =
                pricingDetailExtendeds.GroupBy(pde => new {pde.PricingID, pde.Name, pde.Age})
                    .Select(g => new {g.Key, TheGroups = String.Join(",", g.Select(s => s.Group))}).ToList();
