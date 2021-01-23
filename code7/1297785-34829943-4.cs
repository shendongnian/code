    public Entry CreateEntry(string line)
    {
        string[] parts = line.Split();
        return new Entry()
        {
            Player = parts[0],
            Team = parts[1],
            POS = parts[2],
            HR = Convert.ToInt32(parts[3]),
            RBI = Convert.ToInt32(parts[4]),
            AVG = Convert.ToDouble(parts[5])
        };
    }
