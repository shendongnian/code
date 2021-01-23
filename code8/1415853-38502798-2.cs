    var source = Enumerable.Range(1, 9).ToArray();
    var result = SplitArray(source, 4);
    string report = String.Join(Environment.NewLine, 
      result.Select(item => String.Join(", ", item)));
    // 1, 2, 3, 4
    // 5, 6, 7, 8
    // 9          // <- please, notice, that the last chunk has 1 item only
    Console.Write(report); 
