      // Just some function, right?
      private static Double[] SomeFunctionThatReturnDoubles() {
        return null;
      }
      ...
      double[] TestRunTime = SomeFunctionThatReturnDoubles();
      ...
      // You'll end up with exception since TestRunTime is null
      for (int j = 0; j < TestRunTime.Length; j++)
      {
      }
      ...
