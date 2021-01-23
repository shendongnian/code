    string[] lines = System.IO.File.ReadAllLines("F:\\123.txt");
    List<string> first = new List<string>();
    List<string> second = new List<string>();
    foreach (string line in lines)
    { 
        first.Add(line.Substring(0, 5));
        second.Add(line.Substring(6, 6));
    }
