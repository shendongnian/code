    abstract class RequestBase  { }
    abstract class ResponseBase { }
    /// <summary>
    /// Base class which will handle the request if the derived type is responsible otherwise 
    /// send request to success handler in chain.
    /// </summary>
    internal abstract class HandlerBase<TRequest, TResponse> // contraints
        where TResponse : ResponseBase
        where TRequest : RequestBase
    {
        HandlerBase<TRequest, TResponse> nextHandler;
        protected HandlerBase(HandlerBase<TRequest, TResponse> nextHandler)
        {
            this.nextHandler = nextHandler;
        }
        public TResponse Execute(TRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            try
            {
                if (this.IsResponsible(request))
                    return this.InternalExecute(request);
                else
                    return this.nextHandler.InternalExecute(request);
            }
            catch (Exception exception)
            {
                // log exception and rethrow or convert then throw.
                throw;
            }
        }
        protected abstract TResponse InternalExecute(TRequest request);
        protected abstract bool IsResponsible(TRequest request);
    }
