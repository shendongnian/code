    ICollection collection;
    if (ProductType == "A") 
    {
        collection = new List<classA>();
        ...
    }
    else
    {
        collection = new List<classB>();
        ...
    }
    var counter = collection.Count;
