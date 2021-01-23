	public interface Foo
	{
		Task<IEnumerable<StateA>> GetStatesAAsync();
		Task<IEnumerable<StateB>> GetStatesBAsync();
		Task<IEnumerable<IState>> GetBatchStatesAsync(IEnumerable<IState> states);
	}
