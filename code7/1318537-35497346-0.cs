	public interface IMessageSub { }
	
	public class MessageSub<T> : IMessageSub where T : class
	{
		public IMessageBus Bus { get; set; }
		public ISubscription<T> Sub { get; set; }
	}
	
	public interface IDataChangedService
	{
		IMessageSub ProcessData(string topic, string subscription);
	}
	
	public interface IDataChangedService<T> : IDataChangedService where T : class
	{
		MessageSub<T> ProcessData(string topic, string subscription);
	}
	
	public class DataChangedService<T> : IDataChangedService<T> where T : class
	{
		IMessageSub IDataChangedService.ProcessData(string topic, string subscription)
		{
			return this.ProcessData(topic, subscription);
		}
	
		public MessageSub<T> ProcessData(string topic, string subscription)
		{
			// Some code
		}
	
		// More code
	}
