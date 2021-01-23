      // Possible operations
      Dictionaty<String, Func<int, int, int, MyObject>> operations =
        new Dictionaty<String, Func<int, int, int, MyObject>>() {
          {"Cube.Attach", (x, y, z) => Cube.Attach(x, y, z);},
          {"Tree.Attach", (x, y, z) => Tree.Attach(x, y, z);},
          {"Plain.Attach", (x, y, z) => Plain.Attach(x, y, z);},
          {"Terrain.Attach", (x, y, z) => Terrain.Attach(x, y, z);},
          ... 
        }
      ...
      // Please, notice spaces and minus sign (-125)
      String source = ":Cube.Attach(100, 18, -125);";
      ...
      String pattern = @"^:(?<Func>[A-Za-z.]+)\((?<Args>.+)\);$";
      Match match = Regex.Match(source, pattern);
      if (match.Success) {
        // Operation name - "Cube.Attach" 
        // Comment it out if you don't want it 
        String func = match.Groups["Func"].Value;
        // Operation arguments - [100, 18, -125]
        int[] args = match.Groups["Args"].Value
          .Split(',')
          .Select(item => int.Parse(item, CultureInfo.InvariantCulture))
          .ToArray();
        // Let's find out proper operation in the dictionary and perform it
        // ... or comment it out if you don't want perform the operation here
        operations[func](args[0], args[1], args[2]); 
      }
