    var texts = new List<string> {"-87.98 65", "-86.98 75", "-97.98 78", "-81.98 65"};
    List<IEnumerable<double>> numerics = 
         texts.Select(s => new List<double>(s.Split().Select(sub => Double.Parse(sub, CultureInfo.InvariantCulture))))
              .Cast<IEnumerable<double>>()
              .ToList();
