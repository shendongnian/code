    public List<Skier> GetTop3()
    {
    var list = Skiers.OrderByDescending(sk=> sk.Value.Score).Take(3).ToList();
    return list;
    }
