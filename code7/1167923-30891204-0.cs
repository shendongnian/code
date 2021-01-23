    public void ConutNumber(int count)
    {
        ...
        GoThroughElements(count);
        ...
    }
    public void GoThroughElements(int count)
    {
        foreach(var value in ValuesAdd1)
        {
            if(count == 1)
            {
                Console.WriteLine(i, ii);
            }
            else if(count > 1)
            {
                GoThroughElements(--count);
            }
            else
            {
                throw new Exception("Wrong count!");
            }
        }
    }
