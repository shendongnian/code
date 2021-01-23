    public Entry CreateEntry(string line)
    {
        string[] parts = line.Split();
        return new Entry()
        {
            Player = parts[0],
            Team = parts[1],
            //...
        };
    }
