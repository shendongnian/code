     String result = Regex.Replace(original, pattern, (MatchEvaluator) ((match) => {
       Object v = test
         .GetType()
         .GetProperty(match.Value.Substring(match.Value.LastIndexOf('.') + 1))
         .GetValue(test);
       return v == null ? "NULL" : v.ToString(); 
     }));
