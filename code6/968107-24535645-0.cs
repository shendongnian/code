    using (new OperationContextScope(client.InnerChannel))
    {
        var endPoint = new EndpointAddress(url);
        var authCookie = new System.Net.Cookie("Auth", cookie);
        var cookies = new CookieContainer();
        cookies.Add(new Uri(url), authCookie);
        var httpRequest = new System.ServiceModel.Channels.HttpRequestMessageProperty();
        OperationContext.Current.OutgoingMessageProperties.Add(System.ServiceModel.Channels.HttpRequestMessageProperty.Name, httpRequest);
        httpRequest.Headers.Add(HttpRequestHeader.Cookie, cookies.GetCookieHeader(endPoint.Uri));
     
        var authChecked = client.CheckAuthorization(request);
    }
