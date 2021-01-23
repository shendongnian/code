	public class Foo
	{
		private readonly TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		public Task GetStateA()
		{
			// Do stuff;
			return tcs.Task;
		}
	
		public Task GetStateB()
		{
			//Do stuff
			return tcs.Task;
		}
	
		public async Task QueryApiAsync()
		{
			// Query the API
			tcs.SetResult(true);
		}
	}
