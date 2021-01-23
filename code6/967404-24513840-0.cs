    public class Class1
    { 
      private static Object thisLock = new Object();
      private static async Task Task1(string name)
      {
          AddToList(name);
      }
      private static AddToList(string name)
      {
          lock(thisLock)
          {
              if(People.names == null) People.names = new List<string>();
              People.names.Add(name);
          }
      }
    }
    public static class People
    {
        public static List<string> names {get; set;}
    }
    
