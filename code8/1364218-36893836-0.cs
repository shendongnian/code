    class Program
	{
		static void Main(string[] args)
		{
			var own = ReceiverFactory.Create<OwnInterpreter>();
			var other = ReceiverFactory.Create<OtherInterpreter>();
			own.Start();
			other.Start();
			Console.ReadLine();
		}
	}
	interface IInterpreter
	{
		void DoSomething();
	}
	class OwnInterpreter : IInterpreter
	{
		public void DoSomething() { Console.WriteLine("Own"); }
	}
	class OtherInterpreter : IInterpreter
	{
		public void DoSomething() { Console.WriteLine("Other"); }
	}
	abstract class ReceiverBase<T> where T: IInterpreter, new()
	{
		public T Interpreter { get; set; }
		public ReceiverBase()
		{
			Interpreter = new T();	
		}
		public void Start()
		{
			Interpreter.DoSomething();
		}
	}
	class SpecialReceiver : ReceiverBase<OwnInterpreter> { }
	class OtherReceiver : ReceiverBase<OtherInterpreter> { }
	static class ReceiverFactory
	{
		private static Dictionary<string, object> factories = new Dictionary<string, object>();
		static ReceiverFactory()
		{
			RegisterFactory(() => new SpecialReceiver());
			RegisterFactory(() => new OtherReceiver());
		}
		public static void RegisterFactory<T>(Func<ReceiverBase<T>> factory) where T : IInterpreter, new()
		{
			factories.Add(typeof(T).FullName, factory);
		}
		public static ReceiverBase<T> Create<T>() where T : IInterpreter, new()
		{
			var type = typeof(T);
			return ((Func<ReceiverBase<T>>)factories[type.FullName]).Invoke();
		}
	}
