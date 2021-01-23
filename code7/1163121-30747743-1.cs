    var nameList = List<String>(MyList.Count);
    foreach(var item in MyList) {
      nameList.Add(item.Name);
    }
    
    var array = nameList.ToArray(); // this is still LINQ,
                                    // but I didn't want to bother
                                    // with re-allocating the array
                                    // or with using indexing
