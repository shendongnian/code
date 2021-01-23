    List<double> doubles = new List<double>();
    foreach (string s in splitted)
    {
        doubles.Add(double.Parse(s, new CultureInfo("fr-FR")));
    }
