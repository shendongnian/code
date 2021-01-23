     List < Signal > collection = new List < Signal > ();
     collection.AddRange((new[] 
     {
     	new Signal
     	{
     		Name = "Hello",
     		Value = 1,
     		rawValue = new ObservableCollection < RawVal > ((new[] {
     			new RawVal { name = "A", value = 1}, 
     			new RawVal {name = "B", value = 1}
     		}).ToList()),
     	},
     	new Signal {
     		Name = "World",
     		Value = 2,
     		rawValue = new ObservableCollection < RawVal > ((new[] {
     			new RawVal {name = "A", value = 1}, 
     			new RawVal {name = "B", value = 1}
     		}).ToList()),
     	}
     }).ToList());
    
     this.DataContext = collection;
