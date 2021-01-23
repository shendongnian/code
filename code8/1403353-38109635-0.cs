    public async Task<string> AdminGetState(ActorId actorId, string interfaceName){
       //Find the type information for "interfaceName".  (Assuming it's in the executing assembly)
       var interfaceType = Assembly.GetExecutingAssembly().GetType(interfaceName);
       //Use reflection to get the Create<> method, and generify it with this type
       var createMethod = typeof(ActorProxy).GetMethod(nameof(ActorProxy.Create)).MakeGenericMethod(interfaceType);
       //Invoke the dynamically reflected method, passing null as the first argument because it's static
       IUserActor proxy = (IUserActor)createMethod.Invoke(null,new object[] { actorId });
       var state = await proxy.AdminGetStateJson();
       return JsonConvert.SerializeObject(state);
    }
