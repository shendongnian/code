     private void SignIn()
        {
            RestRequest request = new RestRequest("Sitefinity/Authenticate", Method.GET);
            IRestResponse response = _restClient.Execute(request);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    request = new RestRequest("Sitefinity/Authenticate/SWT?realm={realm}&redirect_uri={redirectUri}&deflate=true", Method.POST);
                    request.AddUrlSegment("realm", _baseUrl);
                    request.AddUrlSegment("redirectUri", "/Sitefinity");
                    request.AddParameter("wrap_name", _username, ParameterType.GetOrPost);
                    request.AddParameter("wrap_password", _password, ParameterType.GetOrPost);
                    request.AddParameter("sf_persistent", "true", ParameterType.GetOrPost);
                    response = _restClient.Execute(request);
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            if (response.ResponseUri.AbsolutePath == "/Sitefinity/SignOut/selflogout")
                            {
                                SelfLogout();
                            }
                            break;
                        case HttpStatusCode.Unauthorized:
                            throw new SitefinityException("Invalid username or password");
                        default:
                            break;
                    }
                    break;
                case HttpStatusCode.Redirect:
                    throw new NotImplementedException("External STS not supported");
                default:
                    break;
            }
        }
