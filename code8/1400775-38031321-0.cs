    var notFoundInEvents = obCollection.Where(x => !(events.Any(o => o.Home == x.Home))).ToList();
    foreach (var toBeRemoved in notFoundInEvents)
    {
        obCollection.Remove(toBeRemoved);
    }
