    for(int j=set.Count-1; j >= 0; j--)
    {
        for (int i = subSet.Count-1; i >= 0; i--)
        {
            if (subSet[i].IsProperSubsetOf(set[j]))
            {
                subSet.RemoveAt(i);
                set.RemoveAt(j);
                break;
            }
         }
    }
