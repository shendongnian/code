    dateList.Sort();
    if (dateList.Count > 1)
    {
        for (int i = 0; i < dateList.Count - 1; i++)
        {
            DateTime currrent = dateList[i].Date;
            DateTime next = dateList[i + 1].Date;
            DateTime expected = currrent.AddDays(1);
            if (next != expected)
            {
                dateList.Insert(++i, expected);
            }
        }
    }
