      using System.Dynamic;
      ...
      List<string> Values = new List<string>() {
        "10", "20", "30"
      };
      ...
      dynamic variables = new ExpandoObject();
      for (int i = 0; i < Values.Count; ++i)
        (variables as IDictionary<String, Object>).Add(
           ((char) ('a' + i)).ToString(), 
           Values[i]);
      ...
      // 10
      Console.Write(variables.a);
