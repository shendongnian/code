    if (MyDictionary != null && MyDictionary.ContainsKey(some_string)
    {
        ...
    }
    else
    {
        if (MyDictionary == null)
        {
            MyDictionary = new Dictionary<String, MyCustomType>(); 
        }
        MyDictionary.Add(some_string, myCustomType);
    }
