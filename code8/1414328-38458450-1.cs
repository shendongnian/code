    collection.GroupBy(item => item.Name, (key, g) => new
            {
                Name = key,
                MaxValue = g.Max(i => i.Value),
                MinValue = g.Min(i => i.Value)
            });
