    Dictionary<long, List<string>> _summary;
    public Dictionary<long, List<string>> Summary
    {
        get { return _summary; }
        set
        {
            _summary = value;
            foreach (var member in Members)
            {
                List<string> l;
                if (_summary.TryGetValue(member.objectId, out l))
                    member.summary.AddRange(l);            }
        }
    }
