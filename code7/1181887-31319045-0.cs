    var output = new List<string>();
    var lines = File.ReadAllLines("file.csv");
    
    for(int i = 0; i < lines.Length; i+=3)
    {
        var groupedLine = "grouping logic here" + lines[i];
        output.Add(groupedLine);
    }
    
    File.WriteAllLines("newOutput.csv",output);
