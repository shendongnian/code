    //  This version is much safer. 
    public void SetStats(IEnumerable<Stat> stats)
    {
        var cstype = this.GetType();
        foreach (var stat in stats) {
            var prop = cstype.GetProperty(stat.Name.ToString());
            prop.SetValue(this, new Stat(stat));
        }
    }
