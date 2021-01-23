    static void Dump(object x)
    {
      Dump(x, 0, new HashSet<object>());
    }
    static void Dump(object x, int indent, HashSet<object> seen)
    {
      if (seen.Contains(x)) // stop cycles
        Console.WriteLine("(saw this already)");
      else
      {
        seen.Add(x);
        var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
        foreach (var f in x.GetType().GetFields(bindingFlags))
        {
          var value = f.GetValue(x);
          var valueTypeStr = value == null ? "null" : value.GetType().Name;
          Console.WriteLine("{0}{1} {2} = [{3}]", new string(' ', indent), f.FieldType, f.Name, valueTypeStr);
          if (value != null && !value.GetType().IsPrimitive && !(value is string))
            if (value is IEnumerable<object>)
            {
              int index = 0;
              foreach (var item in (IEnumerable<object>)value)
              {
                Console.WriteLine("{0}[{1}]", new string(' ', indent + 2), index++);
                Dump(item, indent + 4, seen);
              }
            }
            else
              Dump(value, indent + 2, seen);
        }
      }
    }
