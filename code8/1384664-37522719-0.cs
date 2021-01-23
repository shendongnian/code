      Dictionaty<String, Func<int, int, int, MyObject>> operations =
        new Dictionaty<String, Func<int, int, int, MyObject>>() {
          {"Cube.Attach", (x, y, z) => Cube.Attach(x, y, z);},
          ... 
        }
      ...
      // Please, notice spaces and minus sign (-125)
      String source = ":Cube.Attach(100, 18, -125);";
      ...
      String pattern = @"^:(?<Func>[A-Za-z.]+)\((?<Args>.+)\);$";
      Match match = Regex.Match(source, pattern);
      if (match.Success) {
        // "Cube.Attach" 
        String func = match.Groups["Func"].Value;
        // [100, 18, -125]
        int[] args = match.Groups["Args"].Value
          .Split(',')
          .Select(item => int.Parse(item, CultureInfo.InvariantCulture))
          .ToArray();
        // Let's find out proper operation in the dictionary and perform it
        operations[func](args[0], args[1], args[2]); 
      }
