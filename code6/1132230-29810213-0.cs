    var tasks = Enumerable.Range(0, 100).Select(_ => 
                {
                    Location location = new Location(vin, start.AddDays(random.Next(range)).ToString())
                    {
                       Coordinates = new GeoCoordinate(random.Next(30, 45),
                                                       random.Next(75, 100));
                    }
                    batchOperation.Insert(location);
                    return LoadGpsPointsForTruckAsync(tableClient, batchOperation); 
                }
    await Task.WhenAll(tasks);
