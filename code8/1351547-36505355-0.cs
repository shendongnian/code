    if (line != "100")
    {
       var d = line.Split().Select(f => double.Parse(f, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture));
       var myList = new List<double>(d); // Instead of creating the list and then using AddRange, we initialize it with the enumerable values
       lista.Add(myList);
    }
