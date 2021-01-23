    var lines = File.ReadAllLines("filename.txt");
    
    var results = lines.Select(line => line.Split(' '))
                       .Select(split => new { Character = split[0], Number = split[1] });
    // this is your data, now you can play with it
   
    string allChars = string.Join(string.Empty, results.Select(r => r.Character));
    string[] allNumbers = results.Select(r => r.Number).ToArray();
