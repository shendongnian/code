      using System.Text.RegularExpressions;
      ...
      public string MyURL {
        get {
          return _MyURL;
        }
        set {
          _MyURL = Regex.Replace(value, @"\s", (MatchEvaluator) ((match) => ""));
        }
      }
