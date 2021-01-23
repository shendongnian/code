    public class MyService : MyContract
    {
    	private Dictionary<Type, Action<object>> eventHandlers;
    
    	static Action<object> GetHandler<T>(IEventHandler<T> handler)
    	{
    		var parameter = Expression.Parameter(typeof(object), "t");
    		var body = Expression.Call(
    			Expression.Constant(handler),
    			"HandleEvent", null,
    			Expression.Convert(parameter, typeof(T)));
    		return Expression.Lambda<Action<object>>(body, parameter).Compile();
    	}
    	public MyService()
    	{
    		eventHandlers = new Dictionary<Type, Action<object>>()
    		{
    			{ typeof(string), GetHandler(new SlowButAccurateEventHandler<string>()) },
    			{ typeof(int), GetHandler(new FastEventHandler<int>()) },
    		};
    	}
    	public void RouteToEventHandler(object userEvent)
    	{
    		Action<object> handler;
    		if (eventHandlers.TryGetValue(userEvent.GetType(), out handler))
    			handler(userEvent);
    	}
    }
