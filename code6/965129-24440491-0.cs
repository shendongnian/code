    public static double? TryParse(string input)
    {
      double result;
      var success = double.TryParse(input, out result);
      return success ? result as double? : null;
    }
