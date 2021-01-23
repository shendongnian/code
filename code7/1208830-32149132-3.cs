    public class Program
    {
    	public static void Main()
    	{
            var handler = new DynamicConstructor(typeof (SampleHandler1)).New();
    		invokeIConsumeFor(handler, "Sample Message");
    	}
    
        private static void invokeIConsumeFor(object handler, string message)
    	{
    		var executer      = new DynamicGenericInterfaceExecuter(handler, "IConsume`1");
    		var messageObject = executer.GetTypeArgumentConstructor(0, Type.EmptyTypes).New();
    
    		((IBaseMessage) messageObject).Name = message;
    
            executer.Method("Consume", messageObject.GetType()).Call(messageObject);
    	}
    }
    
    public class DynamicGenericInterfaceExecuter
    {
    	private object instance;
        private Type genericInterfaceFromType;
    	private Type[] genericTypeArguments;
    	
    	public DynamicGenericInterfaceExecuter(object instance, string interfaceName)
    	{
    		this.instance                 = instance;
    		this.genericInterfaceFromType = instance.GetType().GetInterface(interfaceName);
    		this.genericTypeArguments     = this.genericInterfaceFromType.GetGenericArguments();
    	}
    
    	public MethodExecuter Method(string methodName, params Type[] parameterTypes)
    	{
    		return new MethodExecuter(this.instance, this.genericInterfaceFromType, methodName, parameterTypes);
    	}
    
        public DynamicConstructor GetTypeArgumentConstructor(int typeArgumentIndex, params Type[] constructorParameterTypes)
    	{
            return new DynamicConstructor(this.genericTypeArguments[typeArgumentIndex], constructorParameterTypes);
    	}
    }
    
    public class DynamicConstructor
    {
    	private System.Reflection.ConstructorInfo constructor;
    
    	public DynamicConstructor(Type type, params Type[] constructorParameters)
        {
            this.constructor = type.GetConstructor(constructorParameters);
        }
    
    	public object New(params object[] constructorArguments)
        {
            return this.constructor.Invoke(constructorArguments);
        }
    }
    
    public class MethodExecuter
    {
    	private object instance;
    	private System.Reflection.MethodInfo method;
    	public MethodExecuter(object instance, Type containerType, string methodName, Type[] methodParameters)
    	{
    		this.instance = instance;
    		this.method   = containerType.GetMethod(methodName, methodParameters);
    	}
    	public void Call(params object[] arguments)
    	{
    		this.Invoke(arguments);
    	}
    	public object Invoke(params object[] arguments)
    	{
    		return this.method.Invoke(instance, arguments);
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
