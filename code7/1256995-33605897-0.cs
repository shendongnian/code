    // Convert all B objects to A objects
    var objectBsAsAs = ListB.Select(x => new ObjectA() { ComputerName = x.ComputerName, LastLogonUserName = x.LastLogonUserName });
    // Add all B objects to the list of A objects
    var allComputers = ListA.AddRange(objectBsAsAs);
    // Get a distinct list based on ComputerName
    var distinct = ListA.Distint(new ComputerNameComparer());
    
    private class ComputerNameComparer : IEqualityComparer<ObjectA> 
    {
    	public bool Equals(ObjectA a, ObjectA b) 
    	{
    		return a.ComputerName == b.ComputerName;
    	}
    }
