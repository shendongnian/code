    var webAuthenticationResult = 
        await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, 
        requestUri, 
        callbackUri);
    if (webAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success) {
         //String for service response
         var data = webAuthenticationResult.ResponseData; 
         ...
    } else {
         ...
    }
