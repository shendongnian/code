    var list = collection.ToList(); //ToArray() also possible
    for (int i = 0; i < list.Count(); i++)
    { 
      dictionary.Add(i, list[i]);
    }
