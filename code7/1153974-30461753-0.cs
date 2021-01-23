    products.GroupBy(p => p.Id)
            .Select(g => g.OrderByDescending(gg => gg.Name)
                          .Where(gg => gg.Name != null)
                          .Select(gg => new { gg.Id, gg.Name })
                          .First());
