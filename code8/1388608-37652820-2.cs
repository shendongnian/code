    // "T read" is the read line from the CSV.
    T value;
    var tup = new Tuple<string, string>(name, date);
    if (myDictionary.TryGetValue(tup, out value))
    {
        // modify value by calling the interface method / using the interface property
        value.AddVolume();
    }
    else 
    {
        // add value to list and dictionary
        myDictionary.Add(tup, read);
        myList.Add(read);
    }
