    IList l;
    
    if (ProductType == "A") 
    {
        l = new List<classA>();
        ...
    }
    else
    {
        l = new List<classB>();
        ...
    }
    
    var counter = l.Count; // Count is a property here.
