    for (int i = 0; i < list[0].Length; i++)
    {
        reciplist.Add(new RecipientMap
        {
            IPgroupID = list[0][i],
            PCgroupID = list[1][i]
        });
    }
