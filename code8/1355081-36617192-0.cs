    // First of all define a source - it can be an array, file - whatever:
    // var source = hoursArray; // e.g. source for array
    var source = File
      .ReadLines(@"C:\MyFile.txt")         //TODO: put actual file here
      .SelectMany(line => line.Split(',')) //TODO: put actual separator here
      .Select(item => int.Parse(item));
    
    // having got source (IEnumerable<int>) let's compute min, max, average
    
    int max = 0;
    int min = 0;
    double sum = 0.0; // to prevent integer division: 7/2 = 3 when 7.0 / 2 = 3.5
    int count = 0;
    boolean firstItem = true;
    
    foreach (item in source) {
      sum += item; 
      count += 1;
    
      if (firstItem) {
        firstItem = false;
        max = item;
        min = item;
      } 
      else if (item > max)
        max = item;
      else if (item < min)
        min = item;
    }
    
    Console.Write("Min = {0}; Max = {1}; Average = {2}", min, max, sum / count);
