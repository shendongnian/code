    var count = 0;
    var spacesPerLevel = spaces.Count / numLevels;
    var levels = spaces
                   .GroupBy(t => count++ / spacesPerLevel)
                   .Select(t => new Level(new ParkingSpaces(t.ToList())))
                   .ToList();
    AddRange(levels);
