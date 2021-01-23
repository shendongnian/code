    var d = new List<Tuple<string, double>>();
    .
    .
    .
    while ((line = file.ReadLine()) != null)
    {
        d.Add(Tuple.Create(line, p.calculate_CS(line, document)));
    }
    .
    .
    .
    foreach (double item in d.OrderByDescending(t => t.Item2))
    {
        fileW.WriteLine("{0} from line {1}", item.Item2, item.Item1);
    }
