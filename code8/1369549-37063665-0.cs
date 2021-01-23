	void Main()
	{
		Watcher<NumericEvent> aWatcher = new Watcher<NumericEvent>();
		aWatcher.TheAction = new AlphaAction<NumericEvent>();
		aWatcher.TheAction.AnActionPropertyA = ne => ne.GetProperty1();
		aWatcher.TheAction.AnActionPropertyB = ne => ne.GetProperty2();
		NumericEvent anEvent = new NumericEvent("bla", 3);
		if (aWatcher.GType() == anEvent.GetType())
			aWatcher.Call(anEvent);
	}
	
	internal abstract class BaseAction<T> where T : IEvent
	{
		public abstract void Run(T theEvent);
	}
	
	internal class AlphaAction<T> : BaseAction<T> where T : IEvent
	{
		internal delegate string ActionPropertyA(T theEvent);
		internal delegate int ActionPropertyB(T theEvent);
	
		internal ActionPropertyA AnActionPropertyA;
		internal ActionPropertyB AnActionPropertyB;
	
		public override void Run(T theEvent)
		{
			Console.Write(AnActionPropertyA(theEvent));
			Console.Write(AnActionPropertyB(theEvent));
		}
	}
	
	internal interface IEvent
	{
	}
	
	internal class NumericEvent : IEvent
	{
		private readonly string _eventProperty1;
		private readonly int _eventProperty2;
	
		public NumericEvent(string p1, int p2)
		{
			_eventProperty1 = p1;
			_eventProperty2 = p2;
		}
	
		public string GetProperty1()
		{
			return _eventProperty1;
		}
		public int GetProperty2()
		{
			return _eventProperty2;
		}
	}
	
	internal class Watcher<T> where T : IEvent
	{
		internal AlphaAction<T> TheAction;
	
		internal Type GType()
		{
			return typeof(T);
		}
	
		internal void Call(T theEvent)
		{
			TheAction.Run(theEvent);
		}
	}
