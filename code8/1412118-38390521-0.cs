	void Main()
	{
		using (var builder = new Builder())
		{
			var foo = builder.Create();
			// do smtg
		}
	}
	
	public class Foo
	{
		public Foo(Dep instance)
		{
		}
	}
	
	public class Dep : IDisposable
	{
		public void Dispose()
		{
			Console.WriteLine($"{this.GetType().Name} disposed!");
		}
	}
	
	public class Builder : IDisposable
	{
		private List<IDisposable> _disposables = new List<System.IDisposable>();
		
		public Foo Create()
		{
			var dep = new Dep();
			_disposables.Add(dep);
			
			var foo = new Foo(dep);
			return foo;
		}
	
		public void Dispose()
		{
			foreach(var d in _disposables)
				d.Dispose();
				
			Console.WriteLine($"{this.GetType().Name} disposed!");
		}
	}
