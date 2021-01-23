    public static class DictionaryOfShuttleState
    {
      static Dictionary<string, string> _dict = new Dictionary<string, string>
      {
        {"Item1", ShuttleState.Item1},
        {"Item2", ShuttleState.Item2},
        {"Item3", ShuttleState.Item3}
      };
    
      public static string GetDictionaryValue(string keyValue)
      {
        string result;
        if(_dict.TryGetValue(keyValue, out result)
        {
          return result;
        }
        else
        {
          return String.Empty
        }
    
      }
    }
