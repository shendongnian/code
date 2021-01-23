    var list = new List<string>(new[] { "1", "2", "3", "a", "b", "a", "b", "c", "1", "2" });
    var sublist = new List<string>(new[] { "a", "b", "c" });
    var start = -1;
    var index = 0;
    while (index < list.Count - sublist.Count)
    {
        for (int i = 0; i < sublist.Count; i++)
        {
            if (list[i + index] == sublist[i] && i == 0)
            {
                start = i + index;
            }
            else if (list[i + index] != sublist[i])
            {
                start = -1;
                index++;
                break;
            }
        }
        if (start != -1)
        {
            list.RemoveRange(start, sublist.Count);
            index -= sublist.Count;
        }
    }
    foreach (var item in list)
    {
        Console.Write(item + ",");
    }
