    static Dictionary<string, bool> ChangeValues(int line, Dictionary<string, bool> values)
    {
      var binary = Convert.ToString(line, 2);
      var key = 'A';
      foreach (var c in binary)
      {
        values[key.ToString()] = c == '1';
        key++;
      }
      return values;
    }
