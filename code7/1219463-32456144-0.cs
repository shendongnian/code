	public Task<int> Parse()
	{
		Task<int> t = null;
		t = Task.Run(() => this.Read(t));
		return t;
	}
	public Task<int> Read(Task<int> t)
	{
		return t.ContinueWith(v => 42);
	}
