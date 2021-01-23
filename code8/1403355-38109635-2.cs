    public async Task<string> AdminGetState(ActorId actorId, string interfaceName){
       //Find the type information for "interfaceName".  (Assuming it's in the executing assembly)
       var interfaceType = Assembly.GetExecutingAssembly().GetType(interfaceName);
       //Use reflection to get the Create<> method, and generify it with this type
       var createMethod = typeof(ActorProxy).GetMethod(nameof(ActorProxy.Create)).MakeGenericMethod(interfaceType);
       //Invoke the dynamically reflected method, passing null as the first argument because it's static
       object proxy = createMethod.Invoke(null,new object[] { actorId });
       //As per your comments, find the "AdminGetStateJson" method here.  You're REALLY trusting that it exists at this point.
       var adminGetStateMethod = interfaceType.GetMethod("AdminGetStateJson");
       Task<string> stateTask = (Task<string>)adminGetStateMethod.Invoke(proxy, null);
       var state = await stateTask;
       return JsonConvert.SerializeObject(state);
    }
