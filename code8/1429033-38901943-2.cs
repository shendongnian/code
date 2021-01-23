    List<myItem> list;
    list.Sort(<.. sort by id ..>);
    for (int i = 0; i < list.Count; i++)
    {
       myItem m = list[i];
       m.Sum1 = m.Value;
       m.Sum2 = m.Sum1;
       if (i < list.Count - 1)
       {
           m.Sum2 += list[i + 1].Value;
       }
       m.Sum3 = m.Sum2;
       if (i < list.Count - 2)
       {
           m.Sum3 = += list[i + 2].Value;
       }
    }
