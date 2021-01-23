    var myDictionary = new Dictionary<object, string>();
    IEnumerable myCollection = new List<string>();
           
    foreach(var item in myCollection)
    {
        // This might be fun if you get two of the same object in the collection.
        // Since this key is based off of the results of the GetHashCode() object in the base object class.
        myDictionary.Add((object) item, item.ToString());
    }
