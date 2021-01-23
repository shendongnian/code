      String text =
        @"123456 // row id 0,0
          234567 // row id 1,0
          345678 // row id 2,0
          456789 // row id 3,0";
      // new Char[] { '\r', '\n' }  - I don't know the actual separator
      // Regex.Match(...) - 1st integer number in the line
      int[] split = text
        .Split(new Char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(line => int.Parse(Regex.Match(line.TrimStart(), "^[0-9]+").Value))
        .ToArray();
      // Test: 
      // 123456
      // 234567
      // 345678
      // 456789
      Console.Write(String.Join(Environment.NewLine, split));
