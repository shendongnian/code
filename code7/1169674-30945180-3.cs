    private static List<string> Simplify(List<string> inputs)
    {
        var simpleList = new List<int>();
        var retval = new List<string>();
        bool infinity = false;
        foreach (string input in inputs)
        {
            if (string.IsNullOrEmpty(input))
                continue;
            if (input.Split('-').Length > 1)
            {
                int min = int.Parse(input.Split('-')[0].Trim());
                int max = int.Parse(input.Split('-')[1].Trim());
                // inclusive
                simpleList.AddRange(Enumerable.Range(min, max - min + 1));
                continue;
            }
            if (input.Trim().EndsWith("+"))
            {
                infinity = true;
                simpleList.Add(int.Parse(input.Trim().Trim('+')));
            } else simpleList.Add(int.Parse(input.Trim()));
        }
        simpleList.Sort();
        for (int i = 0; i < simpleList.Count; i++)
        {
            int currentVal = simpleList[i];
            int q = i;
            while (q < simpleList.Count)
            {
                if (q != simpleList.Count - 1 && simpleList[q] + 1 == simpleList[q + 1])
                {
                    q++;
                    continue;
                }
                if (currentVal == simpleList[q])
                {
                    retval.Add(currentVal.ToString());
                    i = q;
                    break;
                }
                if (currentVal + 1 == simpleList[q])
                {
                    retval.Add(currentVal.ToString());
                    retval.Add(simpleList[q].ToString());
                    i = q;
                    break;
                }
                retval.Add(currentVal + "-" + simpleList[q]);
                i = q;
                break;
            }
        }
        if (infinity)
            retval[retval.Count - 1] = retval[retval.Count - 1] + "+";
        return retval;
    }
