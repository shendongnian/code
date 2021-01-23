    string str = @"534-W1A-R1";
    
    var split = str.Split('-');
    
    string code = split.First();
    string phase = new string(split.ElementAt(1).Skip(1).Take(1).ToArray());
    string zone = new string(split.ElementAt(1).Skip(2).Take(1).ToArray());
    
    string result = String.Format("Code={0} Phase={1} Zone={2}", code, phase, zone);
    Console.WriteLine(result);
