    public static class People
    {
      static List<string> _names = new List<string>();
    
      public static void AddName(string name)
      {
         lock (_names)
         {
            _names.Add(name);
         }
      }
    
      public static IEnumerable<string> GetNames()
      {
         lock(_names)
         {
            return _names.ToArray();
         }
      }
    }
    
    public class Threading
    {
         public static async Task DoSomething()
         { 
             var t1 = new Task1("bob");
             var t2 = new Task1("erin"); 
             await Task.WhenAll(t1,t2);  
         }
         private static async Task Task1(string name)
         {
             People.AddName(name);
         }
    }
