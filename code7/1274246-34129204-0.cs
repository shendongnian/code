    Parallel.ForEach(lines.GroupBy(line => line.TheUser), grp => {
        // processing user grp.Key
        foreach(var line in grp) {
            // do the stuff here
        }
    });
