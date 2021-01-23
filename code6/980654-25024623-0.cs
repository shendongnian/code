    [ProtoContract]
    public ref class RequestMessage
    {
    public:
        [ProtoMember(1)]
        Int32 Number1;
        [ProtoMember(2)]
        Int32 Number2;
    };
