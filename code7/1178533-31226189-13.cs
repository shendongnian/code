    public interface IMessageTransformer
    {
    }
    public interface IMessageTransformer<T> : IMessageTransformer where T : class
    {
        T Transform(IIncomingMessage message);
    }
