    var source = File
      .ReadLines(@"C:\Users\p2\Desktop\Liste.txt")
      .Select(line =>
       {
            var splits = line.Split(' '));
            return new Vgl() 
                  {
                      name = splits[0], 
                     gErg = double.Parse(splits[3])
                  };
       }
