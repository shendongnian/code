    Dictionary<long, List<string>> _summary;
    public Dictionary<long, List<string>> Summary
    {
        get { return _summary; }
        set
        {
            _summary = value;
            foreach (var member in Members)
            {
                List<string> list;
                if (_summary.TryGetValue(member.objectId, out list))
                {
                    if (member.summary == null)
                        member.summary = new List<string>();
                    member.summary.AddRange(list);
                }
            }
        }
    }
