    using Ninject;
    using Ninject.Extensions.Interception;
    
    public class LogRequestInterceptor : IInterceptor 
    {
    	public void Intercept(IInvocation invocation)
    	{
    		MethodInfo method = invocation.Request.Method;
    
    		var parameters = method.GetParameters();
    
    		var builder = new StringBuilder();
    
    		for (int index = 0; index < parameters.Length; index++)
    		{
    			object argument = invocation.Request.Arguments[index];
    
    			ParameterInfo parameterInfo = parameters[index];
    
    			if (!parameterInfo.IsOut)
    			{
    				//use any serialization you like
    				string text = $"{parameterInfo.Name} = {argument.ToJson()}, ";
    
    				builder.Append(text);
    			}
    		}
    
    		string joinedParameters = builder.ToString();
    		
    		YourLogging(method.Name, joinedParameters); 
    
    		//LegacyClient method call, don't forget this line
    		invocation.Proceed();
    	}
    }
