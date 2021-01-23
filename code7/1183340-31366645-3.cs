    var things = new List<Thing>
    {
        new Thing { Id = 1, Name = "Fire", ParentId = null },
        new Thing { Id = 2, Name = "Fire2", ParentId = 1 },
        new Thing { Id = 3, Name = "Fire3", ParentId = 2 },
        new Thing { Id = 4, Name = "Blast", ParentId = 2},
        new Thing { Id = 5, Name = "Water", ParentId = null },
        new Thing { Id = 6, Name = "Water2", ParentId = 5 },
        new Thing { Id = 7, Name = "Waterx", ParentId = 6 }
    };
    
    var groupedThings = new List<Thing>();
    
    foreach (var thing in things)
    {
        if (thing.ParentId != null)
        {
            things.First(t => t.Id == thing.ParentId).Things.Add(thing);
        }
        else
        {
            groupedThings.Add(thing);
        }
    }
    
    groupedThings.Dump();
