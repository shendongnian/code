    IEnumerator iEnum = collection.GetEnumerator();
    while (iEnum.GetNext())
    {
      var item = iEnum.Current;
       collection.Add(newItem); // will set up the error
       collection.Remove(item); // will set up the error
    } 
