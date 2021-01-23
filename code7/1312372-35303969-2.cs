    var hourspan = new TimeSpan(1, 0, 0);
    var maxDateTime2 = dateTimes2.Max();
    for (int i = 0; i < dateTimes1.Length; i++)
    {
        var output = string.Format("{0}, {1}",
            i,
            dateTimes2
               .Select((o, index) => new { index = index, value = o })
               .Where(date => dateTimes1[i] - date.value < hourspan || date.value == maxDateTime2)
               .Select(date => date.index)
               .FirstOrDefault());
        Console.WriteLine(output);
    }
