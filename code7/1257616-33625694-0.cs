    void ChangeList(List<int> list)
    {
        list.Add(1);
        list.Add(2);
        for(int i = list.Count - 1; i >= 0; i--)
            if(list[i] <= 1) list.RemoveAt(i);
        list.Add(3); // List values: 2, 3
    }
