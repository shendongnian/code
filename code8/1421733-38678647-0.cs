    List<int> bList = new List<int>(b);
    foreach (int check in a)
    {
        if (bList.Contains(check))
        {
            bList.Remove(check);
        }
    }
    b = bList.ToArray();
