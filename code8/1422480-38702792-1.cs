    String input =
      "5 3 4\n" +
      "3 2 1 1 1\n" +
      "4 3 2\n" +
      "1 1 4 1";
    var raw = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
      .Skip(1) // We don't need 1st control line
      .Select(line => line
        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Reverse() // <- do not forget this!
        .Select(x => int.Parse(x))); 
    // All possible substacks per each stack
    List<HashSet<int>> data = new List<HashSet<int>>();
    foreach (var record in raw) {
      HashSet<int> hs = new HashSet<int>() { 0 };
      data.Add(hs);
      int agg = 0;
      foreach (var item in record)
        hs.Add(agg += item);
    }
    // Values that are in all substacks:
    HashSet<int> intersect = new HashSet<int>(data[0]);
    foreach (var line in data)
      intersect.IntersectWith(line); 
    // And, finally, the maximum one:
    Console.Write(intersect.Max());
