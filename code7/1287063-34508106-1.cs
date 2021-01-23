      Console.WriteLine(
        Comparer<int?>.Default.Compare(null, 7)
        ); // "-1"
      Console.WriteLine(
        Nullable.Compare((int?)null, 7)
        ); // "-1"
      Console.WriteLine(
        new List<int?> { 9, null, 7, 13, }
        .OrderBy(ni => ni).First()
        ); // ""
      // 'Min' is special in that it disregards 'null' values
      Console.WriteLine(
        new List<int?> { 9, null, 7, 13, }
        .Min()
        ); // "7"
