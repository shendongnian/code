    List<int[]> CopyString1 = new List<int[]>();
    CopyString1.AddRange(intArrList);
    List<int[]> CopyString2 = new List<int[]>();
    CopyString2.AddRange(intArrList);
    for (int i = 0; i < CopyString2.Count(); i++)
    {
        for (int j = i; j < CopyString1.Count(); j++)
        {
            if (i != j && CopyString2[i].Count() == CopyString1[j].Count())
            {
                var cnt = 0;
                for (int k = 0; k < CopyString2[i].Count(); k++)
                {
                    if (CopyString2[i][k] == CopyString1[j][k])
                        cnt++;
                    else
                        break;
                }
                if (cnt == CopyString2[i].Count())
                    intArrList.RemoveAt(i);
            }
        }
    }
