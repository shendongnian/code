    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    public void sendmail(EmailEntity emailentity)
    {
      ............
    }
