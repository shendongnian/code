    // Parsing into objects
    var data = System.IO.File
      .ReadLines(@"D:\C#\Tema1\Tema1.txt")
      .Skip(1) //TODO: comment down this line if your file doesn't have a caption
      .Select(line => line.Split('\t'))
      .Select(items => new { // or "new Student() {" if you've designed a Student class
        Year    = int.Parse(items[0]),
        Class   = int.Parse(items[1]),
        Name    = items[2],
        Surname = items[3],
        Average = int.Parse(items[4]), //TODO: Is it Int32 or Double?
      });
    
    ...
    
    // combining back: 
    String result = String.Join(Environment.NewLine, data
      .Select(item => String.Join("\t", 
         item.Year, item.Class, item.Name, item.Surname, item.Average));
    
    Console.Write(result);
