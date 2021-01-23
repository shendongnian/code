            string objectDisplayName = null;
            string tenantId = (System.Security.Claims.ClaimsPrincipal.Current).
                FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            string signedInUserID = (System.Security.Claims.ClaimsPrincipal.Current).
                FindFirst(System.IdentityModel.Claims.ClaimTypes.NameIdentifier).Value;
            string userObjectID = (System.Security.Claims.ClaimsPrincipal.Current).
                FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            ClientCredential credential = new ClientCredential(ConfigurationManager.AppSettings["ida:ClientId"],
                ConfigurationManager.AppSettings["ida:ClientSecret"]);
            // initialize AuthenticationContext with the token cache of the currently signed in user, as kept in the app's EF DB
            AuthenticationContext authContext = new AuthenticationContext(
                string.Format(ConfigurationManager.AppSettings["ida:Authority"], tenantId), new ADALTokenCache(signedInUserID));
            AuthenticationResult result = authContext.AcquireTokenSilent(
                ConfigurationManager.AppSettings["ida:GraphAPIIdentifier"], credential, new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
            HttpClient client = new HttpClient();
            string doQueryUrl = string.Format("{0}/{1}/directoryObjects/{2}?api-version={3}",
                ConfigurationManager.AppSettings["ida:GraphAPIIdentifier"], tenantId,
                objectId, ConfigurationManager.AppSettings["ida:GraphAPIVersion"]);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, doQueryUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                var directoryObject = System.Web.Helpers.Json.Decode(responseString);
                if (directoryObject != null) objectDisplayName = string.Format("{0} ({1})", directoryObject.displayName, directoryObject.objectType);
            }
            return objectDisplayName;
        }
