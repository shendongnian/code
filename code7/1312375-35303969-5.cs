    var hour = new TimeSpan(1, 0, 0);
    var dt2MaxValue = dateTimes2.Max();
    for (int i = 0; i < dateTimes1.Length; i++)
    {
        var output = string.Format("{0}, {1}",
            i,
            dateTimes2
               .Select((o, index) => new { index = index, value = o })
               .Where(dt2 => (dateTimes1[i] - dt2.value) < hour 
                               || dt2.value == dt2MaxValue)
               .Select(dt2 => dt2.index)
               .FirstOrDefault());
        Console.WriteLine(output);
    }
