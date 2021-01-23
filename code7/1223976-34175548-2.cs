    private InstagramConfig _config;
    public async Task< ActionResult> somename(string code)
            {
                if (code != null)
                {
                   _config = new InstagramConfig(["InstgramClientId"],
                                                     ["InstgramClientSecret"],
                                                    ["InstgramRedirectUrl"]
                                                     );
    
                    var instasharp = new InstaSharp.OAuth(_config);
                    var authInfo = await instasharp.RequestToken(code);
                    var user = new InstaSharp.Endpoints.Users(_config, authInfo);
    
                    ViewBag.Username = user.OAuthResponse.User.Username;
                    ViewBag.Token = authInfo.AccessToken;
    
    
                    return View();
                }
    
                return View("name"); 
            }
    
