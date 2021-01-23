    foreach (List<Thing> things in ThingIds.Values) // loop dictionary values, only the lists are relevant
    {
        if (things.Count < 2) 
            continue;  // cannot contain invalid "things"
        Thing lastThing = things[things.Count - 1];
        for (int i = things.Count - 2; i >= 0; i--) // backwards loop to remove via index
        {
            Thing t = things[i];
            if (t.Level > lastThing.Level)
                things.RemoveAt(i);
        }
    }
