    public IEnumerable<Machine> SelectPower(
        IEnumerable<Machine> machines
    ,   Func<IEnumerable<int>,int> powerSelector
    ) {
        var res = new List<Machine>();
        var groups = machines.GroupBy(m => m.Type);
        foreach (var g in groups) {
            var targetPower =  powerSelector(g.Select(m => m.Power));
            var machine = g.First(m => m.Power == targetPower);
            res.Add(machine);
        }
        return res;
    }
