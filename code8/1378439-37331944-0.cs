    var myTempCollection = new List<MyClass>();
    foreach(MyClass item in myEnumerable)
    {
       if (item != myDictionary["someKey"])
       {
            myTempCollection.Add(item);
        }
    }
    var result = myTempCollection;
