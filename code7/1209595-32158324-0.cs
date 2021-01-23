    var numbers = File.ReadLines(path)
                   .Where(line => line.Contains("voice"))
                   .SelectMany(line => line.Split())
                   .Where(str => str.All(c => Char.IsDigit(c) || c == '-' || c == '.'))
                   .Select(str => Double.Parse(str))
                   .ToArray();
  
