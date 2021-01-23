    public interface IHandler<T>
    {
        MessageType Type { get; }
        byte Code { get; }
        int? SubCode { get; }
        bool HandleMeessage(IMessage message, T peer);
    }
