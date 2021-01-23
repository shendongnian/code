    if (line != "100")
    {
       var d = line.Split().Select(f => double.Parse(f, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture));
       lista.Add(new List<double>(d));
    }
