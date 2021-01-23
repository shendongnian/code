    public IEnumerable<string> GetRaces()
    {
        foreach (BaseRace race in races)
        {
            yield return race.ToString();
        }
    }
