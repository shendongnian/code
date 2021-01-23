    var records = File.ReadAllLines(filepath) // read all lines
        .Select(line=> line.Split(','))       //  Process each line one by one and split.
        .Select(s=> new                       // Convert to (anonymous)object with properties. 
        {
            Age = int.Parse(s[0]),
            Gender= s[1],
            MaritalStatus,= s[2],  
            Status= s[3],
            District = int.Parse(s[4]),  
        }).ToList();
