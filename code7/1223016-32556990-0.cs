    var lines = File.ReadLines(fileName);
    var collection = new List<int>();
     
    foreach (var line in lines)
    {
       collection.AddRange(line.Split(' ').Select(n => Convert.ToInt32(n)));  
    }
    
    var result = collection.Distinct().Aggregate((i, j) => i * j); // remove distinct if you don't want eliminate duplicates.
