    class FallSwitch 
    {
         SortedDictionary<int, Action> _cases = new SortedDictionary<int, Action>();
        public void AddCaseAction(int @case, Action action)
        {
            if (_cases.ContainsKey(@case)) throw ArgumentException("case already exists");
            _cases.Add(@case, action);
        }
        public void Execute(int startCase)
        {
            if (!_cases.ContainsKey(startCase)) throw ArgumentException("case doesn't exist");
            var tasks = _cases.Where(pair => pair.Key >= startCase);
            tasks.ForEach(pair => pair.Value());
        }
    }
