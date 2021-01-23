      String source = @"A:<<Default>>;B:<<Default>>;C:<<Default>>;D:<<Default>>;E:<<Default>>";
      String values = "A:aaa;E:eee";
      var dict = values
        .Split(';')
        .Select(item => item.Split(':'))
        .ToDictionary(chunk => chunk[0], chunk => chunk[1]);
      String result = String.Join(";", source
        .Split(';')
        .Select(item => item.Split(':'))
        .Select(item => String.Join(":", 
           item[0],
           dict.ContainsKey(item[0]) ? dict[item[0]] : item[1])));
      // Test
      // A:aaa;B:<<Default>>;C:<<Default>>;D:<<Default>>;E:eee
      Console.Write(result);
