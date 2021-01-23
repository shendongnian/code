	// Compact lambda
	lst.Find(a => a.Name.Equals("Alex"))
	
	// Explicitly typed parameter
	lst.Find((FindPerson a) => a.Name.Equals("Alex"))
	
	// Explicit delegate type
	lst.Find(new Predicate<FindPerson>(a => a.Name.Equals("Alex")))
	
	// Combination of the two above
	lst.Find(new Predicate<FindPerson>((FindPerson a) => a.Name.Equals("Alex")))
	
	// Explicit delegate type through casting
	lst.Find((Predicate<FindPerson>)(a => a.Name.Equals("Alex")))
	
	// Lambda block
	lst.Find(a => { return a.Name.Equals("Alex"); })
	
	// Delegate block
	lst.Find((Predicate<FindPerson>)(delegate(FindPerson a) { return a.Name.Equals("Alex"); }))
	
	// ... etc
