	void Main()
	{
		var repository = new EventStore();
		repository.Events
			.OfType<FooEvent>()
			.Subscribe(evt=>UpdateReadModel(evt));
		
		var aggreate = new MyAggregate(Guid.NewGuid());
		var command = new FooCommand(1);
		aggreate.Handle(command);
		repository.Save(aggreate);
	
	}
	public void UpdateReadModel(FooEvent fooEvent)
	{
		Console.WriteLine(fooEvent.SomeValue);
	}
	
	// Define other methods and classes here
	public class FooCommand
	{
		public FooCommand(int someValue)
		{
			SomeValue = someValue;
		}
		public int SomeValue { get; private set; }
	}
	public class FooEvent
	{
		public FooEvent(int someValue)
		{
			SomeValue = someValue;
		}
		public int SomeValue { get; private set; }
	}
	public interface IAggregate
	{
		List<object> GetUncommittedEvents();
		void Commit();
	}
	public class MyAggregate : IAggregate
	{
		private readonly Guid _id;
		private readonly List<object> _uncommittedEvents = new List<object>();
		public MyAggregate(Guid id)
		{
			_id = id;
		}
	
		public List<Object> GetUncommittedEvents()
		{
			return _uncommittedEvents;
		}
		public void Commit()
		{
			_uncommittedEvents.Clear();
		}
	
		public void Handle(FooCommand command)
		{
			//As a result of processing the FooCommand we emit the FooEvent
			var fooEvent = new FooEvent(command.SomeValue);
			_uncommittedEvents.Add(fooEvent);
		}
	}
	
	public class EventStore
	{
		private readonly ISubject<object> _events = new ReplaySubject<object>();
	
		public IObservable<object> Events { get { return _events.AsObservable(); } }
		public void Save(IAggregate aggregate)
		{
			foreach (var evt in aggregate.GetUncommittedEvents())
			{
				_events.OnNext(evt);
			}
			aggregate.Commit();
		}
	}
