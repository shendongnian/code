    protected R ExecuteServiceMethod<I, R>(Func<I, R> serviceCall) {
	    R result = default(R);
	    ChannelFactory<I> factory = CreateChannelFactory<I>();
	    try {
		    I manager = factory.CreateChannel();
		    result = serviceCall.Invoke(manager);
	    } catch (FaultException<ValidationFaultException> faultException) {
		    faultException.Detail.ValidationErrors.ToList().ForEach(e => ModelState.AddModelError("", e));
	    } finally {
		    if (factory.State != CommunicationState.Faulted) factory.Close();
	    }
	    return result;
    }
    private ChannelFactory<I> CreateChannelFactory<I>() {
	   UserAuthentication user = GetCurrentUserAuthentication();
	   ChannelFactory<I> factory = new ChannelFactory<I>("Manager");
	   if (IsAuthenticated) {
		   factory.Credentials.UserName.UserName = user.UserName;
		   factory.Credentials.UserName.Password = user.Password;
	   }
	   BindingElementCollection elements = factory.Endpoint.Binding.CreateBindingElements();
	   factory.Endpoint.Binding = new CustomBinding(elements);
	   SetDataContractSerializerBehavior(factory.Endpoint.Contract);
	   return factory;
    }
