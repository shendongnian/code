    DateTime target = new DateTime(2015,12,2,15,0,0);
    DateTime closest=DateTime.MinValue;
    long closestTicks=long.MaxValue;
    foreach(var d in dtMyRecords.AsEnumerable().Select(drRow=>drRow.Field<DateTime>("Timestamp")))
    {
    	long currentTicks = Math.Abs(d.Ticks - target.Ticks);
    	if(currentTicks >= closestTicks) continue;
    	closestTicks = currentTicks;
    	closest = d;
    }
    // "closest" will now hold the closest date (or defaults if the sequence contains no elements)
