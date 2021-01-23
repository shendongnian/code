    [OperationContract]
    [WebInvoke(Method="POST", 
        RequestFormat = WebMessageFormat.Json, 
        UriTemplate = "Connection")]
    bool Connection(Data data);
    public bool Connection(Data data)
    {
        /*          */
            return true;
    }
