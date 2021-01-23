    public void Truncate(List<string> newsList, int length)
    {
        foreach(string n in newsList)
        {
            n = n.SubString(0, length);
        }
    }
