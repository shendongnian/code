	public async Task<IEnumerable<DiagnosticsInfo>> Get()
	{
		var list = new List<DiagnosticsInfo>();         
		list.Add(await GetDiagnosticsInfo1());
		list.Add(await GetDiagnosticsInfo2());
		list.Add(await GetDiagnosticsInfo3());
		return list;
	}
