    public Dictionary<long, List<string>> Summary
    {
        get { return _summary; }
        set
        {
            _summary = value;
			
			foreach (var x in
				from member in Members
				join s in _summary on member.objectId equals s.Key
				select new { member, values = s.Value })
			{
				x.member.summary.AddRange(x.values);
			}
        }
    }
