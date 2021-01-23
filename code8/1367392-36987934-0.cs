    public List<Skier> GetTop3()
    {
    var list = Skiers.OrderByDescending(sk=> sk.Score).Take(3).ToList();
    return list;
    }
