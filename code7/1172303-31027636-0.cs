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
    d.OrderByDescending(t => t.Item2);
    .
    .
    .
    foreach (double item in d)
    {
        fileW.WriteLine("{0} from line {1}", d.Item2, d.Item1);
    }
