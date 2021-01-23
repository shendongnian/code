    var someDictionary = new Dictionary<int, string>();
    var kvType = someDictionary.GetType().GetInterfaces()
      .Single(i => i.Name == "ICollection`1")
      .GetGenericArguments().Single();
Because I don't know exactly what you are after, I hard coded the selection of the ICollection`1 interface out of the interfaces implemented.
