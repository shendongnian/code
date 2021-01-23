    string[] lines=System.IO.File.ReadAllLines(filePath)
    var connections = lines
        .Select(d => d.Split(' '))
        .Select(d => new 
        { 
            From = DateTime.Parse(d[0]), 
            To = DateTime.Parse(d[1]), 
            Connections = int.Parse(d[2]) 
        })
        .OrderByDescending(d=>d.Connections).ToList(); 
