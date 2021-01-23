    [OperationContract]
    [WebInvoke(
        Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    public string TestPost(string name)
    {
        return "Hello " + name + "!";
    }
