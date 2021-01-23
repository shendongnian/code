    var dataSet = new[] { -5D, -4D, -3D, -2D, 0D, 1D, 2D, 3D, 4D, 4D };
    var seed = new { Min = Double.PositiveInfinity, Max = Double.NegativeInfinity };
    var aggregate = dataSet.Aggregate(
      seed,
      (a, value) => new {
        Min = Math.Min(a.Min, value),
        Max = Math.Max(a.Max, value)
      }
    );
