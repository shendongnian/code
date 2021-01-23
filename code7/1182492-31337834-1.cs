      List<String> ml = new List<string>();
      foreach (var field in fields)
      {
        String MN = field.Name;
        ml.Add(MN);
        if (field.FieldType.Namespace.Equals("System"))
          continue;
        FieldInfo[] fields2 = field.FieldType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
        if (fields2.Length == 0)
          continue;
        foreach (var field2 in fields2)
        {
          ml.Add(MN + "." + field2.Name);
        }
      }
