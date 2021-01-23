    InstanceCollection instances = referencesIDs
        .Select((id, index) => new {Id = id, Index = index})
        .GroupBy(p => p.Index / 500) // 500 is the max number of IDs
        .SelectMany(g => this.MyService(typeID, g.Select(item => item.Id).ToArray()))
        .ToList();
