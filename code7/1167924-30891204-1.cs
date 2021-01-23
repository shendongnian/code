    public void ConutNumber(int count)
    {
        ...
        GoThroughElements(count);
        ...
    }
    public void GoThroughElements(int count, List<String> recurseValues = new List<String>())
    {
        foreach(String value in ValuesAdd1)
        {
            recurseValues.Add(value);
            if(count == 1)
            {
                // In deepest recursion iterate through the line of values
                foreach(String i in recurseValues)
                    Console.WriteLine(i);
            }
            else if(count > 1)
            {
                GoThroughElements(--count, recurseValues);
            }
            else
            {
                throw new Exception("Wrong count!");
            }
        }
    }
