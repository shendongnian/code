    private static String MyEditLine(string value) {
      var items = value.Split(new char[] { ' ' }, 2);
    
      items[0] = "2000"; // let's change 1000 into 2000
    
      return string.Join(" ", items);
    }
    
    ...
    
    var target = File
      .ReadLines(@"C:\MyFile.txt")
      .Select((line, index) => index != 2
         ? line
         : MyEditLine(line))
      .ToList(); 
    
    File.WriteAllLines(@"C:\MyFile.txt");
