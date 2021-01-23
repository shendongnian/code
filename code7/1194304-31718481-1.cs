    if (list[0][0]!=0)
    {
        for (int i = 0; i < list[0].Length; i++)
        {
            reciplist.Add(new RecipientMap
            {
                IPgroupID = list[0][i],
            });
        }
    }
        
    if (list[1][0]!=0)
    {
        for (int j = 0; j < list[1].Length; j++)
        {
            reciplist.Add(new RecipientMap
            {
                PCgroupID = list[1][j],
            });
        }
    }
