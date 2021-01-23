    .AsEnumerable()
        .Where(p => p.IsParent)
        .OrderBy(p => p.ContractorName)
        .SelectMany(p =>
            {
                // You will return this list
                var list = new List<YourType>();
                // First you add the parent
                list.Add(p);
                // Then you add all the children ordered by name
                list.AddRange(p.Children.OrderBy(c => c.ContractorName).ToList());
                // Finally you return the list
                return list;
            }).ToList();
