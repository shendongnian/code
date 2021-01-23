    void MyMethod(ICollection<int> items, int count, int start)
    {
        while(items.Count < count)
        {
           items.Add(start++);
        }
    }
