    public class Program
    {
    	public static void Main()
    	{
            var handlerType = typeof (SampleHandler1);
    		var genericType = handlerType.GetInterface("IConsume`1");
            var genericArguments = genericType.GetGenericArguments();
            var consumeMethod = genericType.GetMethod("Consume");
    
    		var handlerConstructorInfo = handlerType.GetConstructor(Type.EmptyTypes);
    		var handler = handlerConstructorInfo.Invoke(new object[] {});
    
    		var messageConstructorInfo = genericArguments[0].GetConstructor(Type.EmptyTypes);
            var messageObject = messageConstructorInfo.Invoke(new object[] {});
    
    		((IBaseMessage)messageObject).Name = "Sample Message";
    
            var argsx = new object[] {messageObject};
    
            consumeMethod.Invoke(handler, argsx);
    
    	}
    }
    
    public interface IConsume<in T> where T : class, IBaseMessage
    {
        void Consume(T message);
    }
    
    public class SampleHandler1 : IConsume<SampleMessage>
    {
        public SampleHandler1()
        {
            Console.WriteLine("SampleHandler1 constructed");
        }
    
        public void Consume(SampleMessage message)
        {
            Console.WriteLine("Message consume: " + message.Name);
        }
    }
    
    
    public interface IBaseMessage
    {
    	string Name { get; set; }
    }
    
    public class SampleMessage : IBaseMessage
    {
        public string Name { get; set; }
    }
