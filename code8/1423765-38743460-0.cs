	public class Foo
	{
		public event Action<int, int> SomethingHappened;
	
		public void OnSomethingHappened(int x, int y)
		{
			this.SomethingHappened?.Invoke(x, y);
		}
	}
