    private Dictionary<string, int> _data;
    // Initialize
    private void InitData()
    {
        _data = new Dictionary<string, int>();
        _data.Add("MaleTable2008_0", 75.6m);
        _data.Add("MaleTable2008_1", 75.1m);
        _data.Add("FemaleTable2008_0", 80.6m);
        _data.Add("FemaleTable2008_1", 80.1m);
        _data.Add("MaleTable2010_0", 76.2m);
        _data.Add("MaleTable2010_1", 75.7m);
        _data.Add("FemaleTable2010_0", 81m);
        _data.Add("FemaleTable2010_1", 80.5m);
    }
    private decimal GetAvgLifespan(string group)
    {
        if (_data.ContainsKey(group))
            return _data[group];
        return 0m;
    }
   
