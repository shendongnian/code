    while(list1.Count > 0 && list2.Count > 0)
    {
        if(list1.Count > 0)
        {
            combinedList.Add(list1[0]);
            list1.RemoveAt(0);
        } 
        if(list2.Count > 0)
        {
            combinedList.Add(list2[0]);
            list2.RemoveAt(0);
        } 
    }
