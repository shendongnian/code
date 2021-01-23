    interface IWebRequestHandler
    {
        bool CanHandle(RequestDto request); // assuming the request dto is the base class
    
        WebSocketResponse Handle(RequestDto request, GameSessionServer server);
    }
    
    class CasinoSpinRequestHandler : IWebRequestHandler
    {
        bool CanHandle(RequestDto request)
        {
            return request is CasinoSpinRequestDto;
        }
    
        WebSocketResponse Handle(RequestDto request, GameSessionServer server)
        {
            var spinRequest = request as CasinoSpinRequestDto;
    
            if (spinRequest == null) throw new ArgumentNullException("Incorrect usage of the handler");
            // do your specific spin request code here
        }
    }
    
    public WebSocketResponse HandleRequest(RequestDto request, GameSessionServer server)
    {
        TrySetThreadCulture(request);
        EnsureUserStoredInSession(server.SessionContext, false, SlotIsEngineRNG(server.SessionContext.SystemGameId));
    
        var handlerStrategies = this.GetType().Assembly.GetTypes().Where(x => typeof(IWebRequestHandler).IsAssignableFrom(x)).Select(x => Activator.CreateInstance(x)).Cast<IWebRequestHandler>().ToList();
        // the above is poor man DI, you can just put in the constructor ctor(IEnumerable<IWebRequestHandler>)
        // if your DI supports it, otherwise you can abstract the code above to a 
        // static class so it only gets called once.
    
        var handler = handlerStrategies.FirstOrDefault(x => x.CanHandle(request));
    
        if (handler == null) throw new Exception("Unable to handle this particular request");
    
        // custom request handling
        var wsr = handler.Handle(request, server);
    
        // the consuming of the handler can also be abstracted to a delegate class
        // which merely has the responsibility of sorting out which handler to use
        // save the last handler
        server.SessionContext.Items[typeof(WebSocketHandler)] = this;
        return wsr;
    }
