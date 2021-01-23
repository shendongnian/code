    var flights = fightSegments
        .GroupBy(fs => fs.flightClass)  // get all steps for each flight together
        .Select(fc =>
            new originDestination {
                //flightClass = fc.Key, // if you need this
                pnr = Utils.GeneratePnr(),
                flightSegments = fc         // fc is the list of steps
                    .OrderBy(s => s.Count)  // make sure it is in order
                    .ToList()
            }
        )
