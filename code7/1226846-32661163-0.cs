    string line = Console.ReadLine();
    string split = line.Split(new [] {' '});
    string command = split[0];
    string name = split[1];
    if (line == "create")
    {
        Create(name);
    }
