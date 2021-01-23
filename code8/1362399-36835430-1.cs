    var flights = fightSegments
        .GroupBy(fs => fs.flightClass)
        .Where(fcg => fcg.Count() >= n) // make sure flight has n+ steps
        .Select(fc =>
            new originDestination {
                //flightClass = fc.Key, // if you need this
                pnr = Utils.GeneratePnr(),
                flightSegments = fc
                    .OrderBy(s => s.Count)
                    .ToList()
            }
        )
