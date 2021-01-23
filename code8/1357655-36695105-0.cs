    var years = System.IO.File.ReadLines(@"C:\Users\Josef\Documents\Weather Data\Year.txt");
    var months = System.IO.File.ReadLines(@"C:\Users\Josef\Documents\Weather Data\Month.txt");
    var rains = System.IO.File.ReadLines(@"C:\Users\Josef\Documents\Weather Data\WS1_Rain.txt");
    var yearMonthRainInfos = years
        .Zip(months, (y, m) => new { year = y, month = m })
        .Zip(rains, (x, r) => new { x.year, x.month, rain = r })
        .Where(x => x.year == yearInput);
    foreach (var ymrInfo in yearMonthRainInfos)
    {
        Console.WriteLine("Year:{0}    Month:{1}       Rain:{2}",
            ymrInfo.year, ymrInfo.month, ymrInfo.rain);
    }
