    List<myItem> list;
    
    // sort list by id
    list.Sort(t => t.ID);
    for (int i = 0; i < list.Count; i++)
    {
       myItem m = list[i];
       m.Sum1 = list[i].Value;
       m.Sum2 = m.Sum1 + (i + 1 < list.Count ? list[i + 1].Value : 0);
       m.Sum3 = m.Sum2 + (i + 2 < list.Count ? list[i + 2].Value : 0);
    }
