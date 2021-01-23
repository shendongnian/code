    Dictionary<string, Car> result =
        File.ReadLines("Carlist.txt")
            .Select(line => line.Split(','))
            .ToDictionary(split => int.Parse(split[0]), 
                          split => new Car(split[1], 
                                           split[2], 
                                           split[3], 
                                           split[4]));
