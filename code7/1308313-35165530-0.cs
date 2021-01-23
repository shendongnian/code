    public static List<T> FindCommon<T>(List<List<T>> lists)
    {
        List<uint> Counts = new List<uint>();
        List<List<T>> Matches = new List<List<T>>();
        bool Found = false;
        foreach (List<T> list in lists)
        {
            Found = false;
            for (int i = 0; i < Counts.Count; i++)
            {
                if (Matches[i].Count == list.Count)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        //they not equals
                        if ((dynamic)Matches[i][j] != (dynamic)list[j])
                            goto next_loop;
                        //fully equal, increase count for repeated match found.
                        if (j == list.Count - 1)
                        {
                            Counts[i]++;
                            Found = true;
                            break;
                        }
                    }
                }
                next_loop:
                if (Found) break;
                continue;
            }
    
            if (!Found)
            {
                Counts.Add(1);
                Matches.Add(list);
            }
        }
    
        return Matches[Counts.IndexOf(Counts.Max())];
    }
