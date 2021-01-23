    /// <summary>
    /// Helper method for CORS support.
    /// </summary>
    [OperationContract]
    [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
    void GetOptions();
