    //  Instance method of CharacterStats
    public void SetStats(IEnumerable<Stat> stats)
    {
        var cstype = this.GetType();
        foreach (var stat in stats) {
            var prop = cstype.GetProperty(stat.Name);
            prop.SetValue(this, stat);
        }
    }
    public CharacterStats(IEnumerable<Stat> stats)
    {
        SetStats(stats);
    }
