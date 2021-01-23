    public class ProxyBase : RealProxy
    {
        // ... stuff ...
        public static T Cast<T>(object o)
        {
            return (T)o;
        }
        public static object Create(Type interfaceType, object coreInstance, 
            IEnforce enforce, string parentNamingSequence)
        {
            var x = new ProxyBase(interfaceType, coreInstance, enforce, 
                parentNamingSequence);
            MethodInfo castMethod = typeof(ProxyBase).GetMethod(
                "Cast").MakeGenericMethod(interfaceType);
            return castMethod.Invoke(null, new object[] { x.GetTransparentProxy() });
        }
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            var method = (MethodInfo)methodCall.MethodBase;
            if(method.DeclaringType.IsGenericType
            && method.DeclaringType.GetGenericTypeDefinition().FullName.Contains(
                "System.Runtime.InteropServices.WindowsRuntime"))
            {
                Dictionary<string, string> methodMap = new Dictionary<string, string>
                {   // add problematic methods here
                    { "Append", "Add" },
                    { "GetAt", "get_Item" }
                };
                if(methodMap.ContainsKey(method.Name) == false)
                {
                    throw new Exception("Unable to resolve '" + method.Name + "'.");
                }
                // thanks microsoft
                string correctMethod = methodMap[method.Name];
                method = m_baseInterface.GetInterfaces().Select(
                    i => i.GetMethod(correctMethod)).Where(
                        mi => mi != null).FirstOrDefault();
                
                if(method == null)
                {
                    throw new Exception("Unable to resolve '" + method.Name + 
                        "' to '" + correctMethod + "'.");
                }
            }
            try
            {
                if(m_coreInstance == null)
                {
                    var errorMessage = Resource.CoreInstanceIsNull;
                    WriteLogs(errorMessage, TraceEventType.Error);
                    throw new NullReferenceException(errorMessage);
                }
                var args = methodCall.Args.Select(a =>
                {
                    object o;
                    if(RemotingServices.IsTransparentProxy(a))
                    {
                        o = (RemotingServices.GetRealProxy(a) 
                            as ProxyBase).m_coreInstance;
                    }
                    else
                    {
                        o = a;
                    }
                    if(method.Name == "get_Item")
                    {   // perform parameter conversions here?
                        if(a.GetType() == typeof(UInt32))
                        { 
                            return Convert.ToInt32(a);
                        }
                        return a;                            
                    }
                    return o;
                }).ToArray();
                // this is where it barfs
                var result = method.Invoke(m_coreInstance, args);
                // special handling for GetType()
                if(method.Name == "GetType")
                {
                    result = m_baseInterface;
                }
                else
                {
                    // special handling for interface return types
                    if(method.ReturnType.IsInterface)
                    {
                        result = ProxyBase.Create(method.ReturnType, result, m_enforce, m_namingSequence);
                    }
                }
                return new ReturnMessage(result, args, args.Length, methodCall.LogicalCallContext, methodCall);
            }
            catch(Exception e)
            {
                WriteLogs("Exception: " + e, TraceEventType.Error);
                if(e is TargetInvocationException && e.InnerException != null)
                {
                    return new ReturnMessage(e.InnerException, msg as IMethodCallMessage);
                }
                return new ReturnMessage(e, msg as IMethodCallMessage);
            }
        }
        // ... stuff ...
    }
