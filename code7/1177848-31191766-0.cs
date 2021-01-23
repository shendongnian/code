    for (var i = list1.Count - 1; i >= 0; i--)
    {
        if (list3.Contains(list1[i]))
        {
            list1.RemoveAt(i);
            list2.RemoveAt(i);
        }
    }
