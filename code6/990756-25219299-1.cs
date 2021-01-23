    var collectionFactory = new CollectionFactory(reader);
    var collType = collectionFactory.CreateInstance();
    
    // cast to specific type if needed here.
    var itemBox = collType as ItemBox;
    if (itembox != null)
    {
       // Do stuff..
    }
