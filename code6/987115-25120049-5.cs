    var temp2 = myFullList[0].Select((l, i) => new
    {
        Column = i,
        Mode = myFullList.GroupBy(fl => fl[i]).Select(t => new { Number = t.Key, Count = t.Count() }).OrderByDescending(a => a.Count)
    });
    var result2 = temp2.Select(t => new
    {
        Column = t.Column,
        Mode = t.Mode.Where(m => m.Count == t.Mode.Max(tm => tm.Count))
    });
    foreach (var item in result2)
    {
        for (int i = 0; i < item.Mode.Count(); i++)
        {
            Console.WriteLine(string.Format("{0} {1}", item.Column, item.Mode.ElementAt(i)));
        }
    }
