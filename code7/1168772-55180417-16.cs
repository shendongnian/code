    public interface IMsgHandler<T> where T: class, IMessageType
    {
        Task InvokeMsgCallbackFunc(T msg);
        Func<T, Task> MsgCallbackFunc { get; set; }
        bool IsTryValid(T msg, string refSubscriptionId); // Calls callback only 
                                                          // if Retry is valid
    }
