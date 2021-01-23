    public static IRequestProcessor<IResult> Create(RequestType requestType)
    {
        switch (requestType)
        {
            case RequestType.A:
                return new RequestProcessorA();
            case RequestType.B:
                return new RequestProcessorB();
            default:
                throw new InvalidOperationException();
        }
    }
