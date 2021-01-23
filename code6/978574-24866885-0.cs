    foreach (int i in list.ToList())
    {
        if (i == 2)
        {
            list.Add(666);
            //do something to refresh the foreach loop
        }
        System.Diagnostics.Debug.Write(list[i]);
    }
