    string[] elements = s.Split(); // Contains all elements as strings.
    IDictionary<string, int> elementsMap = new Dictionary<string, int>();
    for (int i = 0; i < elements.Length; i++)
    {
        string name = elements[i];
                
        if (elementsMap.ContainsKey(name))
        {
            elementsMap[name] += 1;
        }
        else
        {
            elementsMap.Add(name, 1);
        }
    }
    return elementsMap;
