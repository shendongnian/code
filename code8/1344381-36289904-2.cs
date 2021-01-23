    //  Instance method of CharacterStats
    public void SetStats(IEnumerable<Stat> stats)
    {
        var cstype = this.GetType();
        foreach (var stat in stats) {
            var prop = cstype.GetProperty(stat.Name.ToString());
            prop.SetValue(this, stat);
        }
    }
    //  Toss in a constructor too. 
    public CharacterStats(IEnumerable<Stat> stats)
    {
        SetStats(stats);
    }
    //  And a factory method
    public static FromStats(IEnumerable<Stat> stats)
    {
        return new CharacterStats(stats);
    }
