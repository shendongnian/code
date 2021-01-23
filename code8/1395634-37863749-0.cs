      // key is sum and value is a list of representations
      Dictionary<int, List<Tuple<int, int>>> solutions = 
        new Dictionary<int, List<Tuple<int, int>>>();
      for (int a = 1; a <= 1000; ++a)
        for (int b = a; b <= 1000; ++b) {
          int sum = a * a * a + b * b * b;
          List<Tuple<int, int>> list = null;
          if (!solutions.TryGetValue(sum, out list)) {
            list = new List<Tuple<int, int>>();
            solutions.Add(sum, list);
          }
          list.Add(new Tuple<int, int>(a, b));
        }
      String report = String.Join(Environment.NewLine,
        solutions.Values
        .Where(list => list.Count > 1)
        .Select(list => String.Join(", ", 
          list.Select(item => String.Format("({0}, {1})", item.Item1, item.Item2)))));
      Console.Write(report);
