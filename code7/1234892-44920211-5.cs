    private static void AppendImageArgs(string serviceName)
    {
      var args = new[]
      {
        new Tuple<string, object>("param1", "Hello"),
        new Tuple<string, object>("param2", 1),
        new Tuple<string, object>("Color", ConsoleColor.Cyan),
      };
      AppendImageArgs(serviceName, args);
    }
