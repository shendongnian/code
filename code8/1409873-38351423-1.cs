    public static ClientContext GetClientContextWithAccessToken(string targetUrl, string accessToken) {
        ClientContext clientContext = new ClientContext(targetUrl);
        clientContext.AuthenticationMode = ClientAuthenticationMode.Anonymous;
        clientContext.FormDigestHandlingEnabled = false;
        clientContext.ExecutingWebRequest +=
            delegate(object oSender, WebRequestEventArgs webRequestEventArgs) {
                webRequestEventArgs.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + accessToken;
                webRequestEventArgs.WebRequestExecutor.WebRequest.Proxy = webProxy;
            };
        return clientContext;
    }
