    Proxy AxoClient = new Proxy
                    {
                        Url = "http://url",
                        ClientId = "ClientId",
                        ClientSecret = "ClientSecret",
                    };
    AxoClient.ObtainAccessTokenFromUsernamePassword
    				(
    					username: user,
    					password: pwd,
    					scope: ScopeEnum.ReadWrite
    				);
    MessageBox.Show(AxoClient.HasAccessToken);
