    Dictionary<string, ArrayList> allIterationValues = new Dictionary<string, ArrayList>();
    foreach (PropertyInfo prop in properties)
    {
        ArrayList iterationList = new ArrayList();
        allIterationValues.Add(prop.Name, iterationList);
        foreach (var element in exampleList)
        {
            iterationList.Add(prop.GetValue(element, null));
        }
    }
    // Check the value of allIterationValues here
