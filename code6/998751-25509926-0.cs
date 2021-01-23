     HttpResponseMessageProperty responseProperty = OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name]
                       as HttpResponseMessageProperty;
     HttpSessionCookieHelper helper = HttpSessionCookieHelper.Create((string)responseProperty.Headers[HttpResponseHeader.SetCookie]);
                HttpRequestMessageProperty requestProperty = new HttpRequestMessageProperty();
                helper.AddSessionIdToRequest(requestProperty);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestProperty;
     
  
