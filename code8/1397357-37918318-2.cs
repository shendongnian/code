      var result = CreateParameterDictionary("A", "B", "C", "D", "E", "F");
    
      String report = String.Join(Environment.NewLine, 
        result.Select(pair => String.Format("{0} = {1}", pair.Key, pair.Value)));
    
      // param1 = A
      // param2 = B
      // param3 = C
      // param4 = D
      // param5 = E
      // param6 = F
      Console.Write(report);
