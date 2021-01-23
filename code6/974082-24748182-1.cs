    Oauth2Service service = new Oauth2Service(
        new Google.Apis.Services.BaseClientService.Initializer());
    Oauth2Service.TokeninfoRequest request = service.Tokeninfo();
    request.AccessToken = token.AccessToken;
    Tokeninfo info = request.Execute();
    string gplus_id = info.UserId;
