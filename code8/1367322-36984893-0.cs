    public void Process<T>(string contents)
		where T : IProcessStuff, new ()
	{
		// Common work to do here
		// ...
		// Specific processing stuff
		T t = new T();
		t.ProcessStuf(contents);
	}
	public interface IProcessStuff
	{
		void ProcessStuf(string contents);
	}
