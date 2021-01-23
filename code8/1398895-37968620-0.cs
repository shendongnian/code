    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    
    namespace ConsoleApplication7
    {
      internal static class Program
      {
        internal static void Main(string[] args)
        {
          var options = new Dictionary<string, string>();
    
          var compareCulture = CultureInfo.CurrentCulture;
          var patternsNeeded = new[] { "abc", "def" };
          var patternsForbidden = new[] { "ghi", "xxx" };
    
          Func<KeyValuePair<string, string>, bool> meetsCriteria =
            kvp => patternsNeeded.Any(p => compareCulture.CompareInfo.IndexOf(kvp.Value, p, CompareOptions.IgnoreCase) >= 0)
               && !patternsForbidden.Any(p => compareCulture.CompareInfo.IndexOf(kvp.Value, p, CompareOptions.IgnoreCase) >= 0);
    
          var dictionaryContainsHits = options.Any(meetsCriteria);
        }
      }
    }
