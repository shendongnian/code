    void MyMethod(IList<int> items, int count, int start)
    {
        while(items.Count < count)
        {
           items.Add(start++);
        }
    }
