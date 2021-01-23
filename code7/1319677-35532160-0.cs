    IDictionary<string, List<Photo>> photos = job.Photos.GroupBy(x => x.Location)
            .Select(group =>
                new
                {
                    Name = group.Key,
                    Photos = group.OrderByDescending(x => x.DateAdded)
                })
            .OrderBy(group => group.Name)
            .ToDictionary(kv=>kv.Name, kv=>kv.Photos.List());
