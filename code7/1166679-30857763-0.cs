    public const string hubName = "A.B.C";
    [HubMethodName(hubName)]
    public void GetNode(SRGetNodeReq req)
    {
        ...
    }
