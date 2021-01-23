    Dictionary<int, Class2> dictionary =
				Class2List.GroupBy(e2 => e2.C2Property2, e2 => e2).Select(elements => elements.First()).ToDictionary(e2 => e2.C2Property2, e2 => e2);
    
    Parallel.ForEach(Class1List, element1 =>
    {
        if (dictionary.ContainsKey(element1.C1Property2))
            element1.C1Property1 = dictionary[element1.C1Property2].C2Property1;
    });
