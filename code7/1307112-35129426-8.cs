	var eventList1 = new List<string>() { "ExampleEvent" };
	var eventList2 = new List<string>() { "ExampleEvent" };
	
    var items = new List<SampleObject>()
    {
        new SampleObject() { Id = "Id", Events = eventList1 },
        new SampleObject() { Id = "Id", Events = eventList2 }
    };
    var duplicates = items.GroupBy(x => x, new SampleObjectComparer())
                     .Where(g => g.Count() > 1)
                     .Select(g => g.Key)
                     .ToList();
					 
	Console.WriteLine(duplicates.Count);
