    List<int> list = new List<int>();
    list.Add(1);
    list.Add(2);
    list.Add(3);
    List<int> list2 = list;
    foreach (int i in list)
    {
        if (i == 2)
        {
            list2.Add(666);
        }
        System.Diagnostics.Debug.Write(list[i]);
        i++; // increment i
    }
    list = list2;
