    for(int j=set.Count-1;j-->0;)
        {
            for (int i = subSet.Count-1;i-->0;)
            {
                if (subSet[i].IsProperSubsetOf(set[j]))
                {
                    set.RemoveAt(j);
                    break;
                }
            }
        }
