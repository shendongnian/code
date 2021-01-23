            var client = new WebServerClient(GetAuthServerDescription(), clientIdentifier: "client id");
            client.ClientCredentialApplicator = ClientCredentialApplicator.PostParameter("secrete");
            // CallBack
            uri = RemoveQueryStringFromUri(callBack);
            state.Callback = new Uri(uri);
            var accessTokenResponse = client.ProcessUserAuthorization();
            if (accessTokenResponse != null)
            {
                //If you have accesstoek then do something 
            }
            else
            {
                // If we don't yet have access, immediately request it.
                client.PrepareRequestUserAuthorization(state).Send();
            }
