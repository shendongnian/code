    var list = new List<string>
    {
        "00:00:40",
        "00:01:00",
        "00:02:10"
    };
    var total = TimeSpan.Zero;
    foreach (var item in list)
    {
        total += TimeSpan.ParseExact(item, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
    }
