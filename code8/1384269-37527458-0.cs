    public static class ConsignmentExtension
    {
       public static IEnumerable<dynamic> SetEach(this IEnumerable<dynamic> input, Action<dynamic> updater)
       {
           foreach (var item in input)
           {
               updater(item);
           }
           return input;
    }
