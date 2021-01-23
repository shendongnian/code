	public class MyServiceThing
	{
		private readonly IObservable<MyType> _myObservable;
		public MyServiceThing()
		{
			_myObservable = Start().ToObservable()
				.SelectMany(_=>/*The thing that defines your observable sequence...*/)
				.Finally(Stop)
				.Publish().RefCount();
		}
		public IObservable<MyType> MyObservable()
		{
			return _myObservable;
		}
		//OR
		//public IObservable<MyType> MyObservable()	{ get { return _myObservable; }	}
			
		private async Task Start() {}
		private async Task Stop() {}
	}
