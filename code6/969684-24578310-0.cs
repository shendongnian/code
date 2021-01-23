    Action<object> first = delegate (object f){ Console.WriteLine(f + "first");};
    Action<object> second = delegate(object s) { Console.WriteLine(s + "second"); };
    Action<object> third = delegate(object t) { Console.WriteLine(t + "third"); };
    
    Dictionary<Type, List<Action<object>>> myDict = new Dictionary<Type, List<Action<object>>>();
    
    myDict.Add(typeof(Bar), new List<Action<object>>());
    myDict[typeof(Bar)].AddRange(new[] { first, second, third });
             
    myDict[typeof(Bar)].Remove(first);
