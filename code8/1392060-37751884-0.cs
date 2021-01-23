        System.Collections.Generic.Dictionary<TKeyItem, TValueItem> myDictionary =
            new System.Collections.Generic.Dictionary<TKeyItem, TValueItem>();
        var key = new TKeyItem();   //create key object
        var val = new TValueItem(); //create value object
        myDictionary.Add(key, val); //add key value pair to the dictionary
        var valueByKey = myDictionary[key];  // it will return val by key
        var valuebyIndex = myDictionary.Values.ElementAt(0); // it will retun val by index
