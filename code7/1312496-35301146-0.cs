    int i = 0;
    int j = 0;
    while (i < dateTimes1.Length)
    {     
        if (dateTimes1[i].Date == dateTimes2[j].Date && dateTimes1[i].Hour == dateTimes2[j].Hour)
        {
            list.Add(i);
            list2.Add(j);
            i++;
        }
        else if (dateTimes1[i] < dateTimes2[j])
        {
            i++;
        }
        else if (dateTimes1[i] > dateTimes2[j])
        {
            if (j < dateTimes2.Length)
            {
                j++;
            }
        }
    }
    for (int k = 0; k < list.Count; k++)
    {
        Console.WriteLine(list[k] + " , " + list2[k]);
    }
