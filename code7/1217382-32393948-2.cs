      using System.Text.RegularExpressions;
      ...
      private string m_MyURL;
      public string MyURL {
        get {
          return m_MyURL;
        }
        set {
          m_MyURL = Regex.Replace(value, @"\s", (MatchEvaluator) ((match) => ""));
        }
      }
