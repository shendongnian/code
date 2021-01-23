    var result1 = myFullList[0].Select((l, i) => new
    {
        Column = i,
        Mode = myFullList.GroupBy(fl => fl[i]).OrderByDescending(t => t.Count()).Select(t => t.Key).FirstOrDefault()
    });
    foreach (var item in result1)
    {
        Console.WriteLine(string.Format("{0} {1}", item.Column, item.Mode));
    }
