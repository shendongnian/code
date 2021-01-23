    public static IRequestProcessor<TResult> Create<TResult>(RequestType requestType)
        where TResult : IResult
    {
        switch (requestType)
        {
            case RequestType.A:
                return (IRequestProcessor<TResult>)new RequestProcessorA();
            case RequestType.B:
                return (IRequestProcessor<TResult>)new RequestProcessorB();
            default:
                throw new InvalidOperationException();
        }
    }
