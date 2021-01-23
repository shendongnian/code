    var dataSet = new Double[] { -5, -4, -3, -2, 0, 1, 2, 3, 4, 4 };
    var seed = new { Min = Double.PositiveInfinity, Max = Double.NegativeInfinity };
    var aggregate = dataSet.Aggregate(
      seed,
      (a, value) => new {
        Min = Math.Min(a.Min, value),
        Max = Math.Max(a.Max, value)
      }
    );
