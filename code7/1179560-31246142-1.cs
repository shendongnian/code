    Console.WriteLine("Vehicle\t" + String.Join("\t", columns));
    foreach (var group in groupedData) {
      Console.Write(group.Key);
      foreach (var column in columns)
        Console.Write("\t" + (group.Values.ContainsKey(column)
          ? group.Values[column].ToString() : String.Empty));
      Console.WriteLine();
    }
