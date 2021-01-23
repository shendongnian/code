    void ChangeList(ref List<int> list)
    {
        list.Add(1);
        list.Add(2);
        list = list.Where(c => c > 1).ToList();
        list.Add(3); // List values: 2, 3
    }
    // ...
    this.ChangeList(ref list);
