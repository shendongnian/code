    public interface IMessageType
    {
        int MsgTypeId { get; }
        Dictionary<string, TryInfo> MsgTryInfo {get; set;}
    }
