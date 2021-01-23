    Dictionary<long, List<string>> _summary;
    public Dictionary<long, List<string>> Summary
    {
        get { return _summary; }
        set
        {
            _summary = value;
            foreach (var member in Members)
            {
                member.summary.AddRange(_summary[member.objectId]);
            }
        }
    }
