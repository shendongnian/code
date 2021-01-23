    // This is the list to which you would ultimately add your value
    List<MyClass> theList;
    // Check if the list is already there
    if (!myDict.TryGetValue(key, out theList)) {
        // No, the list is not there. Create a new list...
        theList = new List<MyCLass>();
        // ...and add it to the dictionary
        myDict.Add(key, theList);
    }
    // theList is not null regardless of the path we take.
    // Add the value to the list.
    theList.Add(newValue);
