    List<myItem> list;
    list.Sort(<.. sort by id ..>);
    for (int i = 0; i < list.Count(); i++)
    {
       myItem m = list[i];
       m.Sum1 = m.Value;
       if (i < list.Count() - 1)
       {
           m.Sum2 = m.Value+ list[i + 1].Value;
       }
       if (i < list.Count() - 1)
       {
           m.Sum3 = m.Value + list[i + 1].Value + list[i + 2].Value;
       }
    }
