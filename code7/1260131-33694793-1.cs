    List<String[]> data = File
      .ReadLines(@"C:\test.txt")
     //.Skip(1) // <- uncomment this to skip caption if the csv has it
      .Select(line => line.Split(';').Take(3)) // 3 items only
      .ToList();
    // Table output (wanted one):
    String report = String.Join(Environment.NewLine, 
      data.Select(items => String.Join("\t", items)));   
    Console.WriteLine(report);
    
    // Column after column output (actual one)
    Console.WriteLine(String.Join(Environment.NewLine, data.Select(item => item[0])));
    Console.WriteLine(String.Join(Environment.NewLine, data.Select(item => item[1])));
    Console.WriteLine(String.Join(Environment.NewLine, data.Select(item => item[2])));
    
