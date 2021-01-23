    int i = 0;
    int j = 0;
    
    while(i < list1.Count && j < list2.Count)
    {
       if (list1[i] == list2[j])
       {
         ++i;
         ++j;
       }
       else if (list1[i] < list2[j])
       {
         removed.Add(list1[i]);
         ++i;
       }
       else // if (list1[i] > list2[j])
       {
         added.Add(list2[j]);
         ++j;
       }
    }
    
    if (i < list1.Count)
    {
      removed.AddRange(list1.GetRange(i,list1.Count));
    }
    if (j < list2.Count)
    {
      added.AddRange(list2.GetRange(j,list2.Count));
    }
