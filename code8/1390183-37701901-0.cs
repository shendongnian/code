    IEnumerable<Mission> FindMissions(IEnumerable<Mission> missions, string flight, string location)
    {
        var results = new List<Mission>();
        foreach (Mission m in missions)
        {
            if (m.Type == flight && m.Location == location) 
            {
                results.Add(m);
            }
        }
        return results;
    }
