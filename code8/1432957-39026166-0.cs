      var test = File.ReadAllBytes("map.txt");
      if (test.All(b => char.IsNumber((char)b))) throw new Exception("only numbers found!");
      if (!test.Any(b => b == '\n')) throw new Exception("no linebrakes found!");
      Console.WriteLine("--- char stats ---");
      Console.WriteLine();
      Console.WriteLine(string.Join("\r\n", test.GroupBy(c => c).OrderBy(g=>-g.Count()).Select(g => (g.Key < ' ' ? "0x" + g.Key.ToString("x").PadLeft(2,'0') : "   " + (char)g.Key) + " - count: " + g.Count())));
