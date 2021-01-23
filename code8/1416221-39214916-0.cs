     public ClientContext CreateRemoteSharePointContext(string TargetWebURL, SharePointContext CurrentSharePointContext)
        {
            //In order for us to create a share point client context that points to 
            //site other then the site that this app is running we need to copy some url parameters from the current 
            //context. These parameters are found on the current share-point context 
            NameValueCollection QueryString = Request.QueryString;
            //Since, The Query string is a read only collection, a use of reflection is required to update the 
            //values on the request object,  we must use the current request object because it contains 
            //security and other headers/cookies that we need for the context to be created, Grab the url params that we need 
            //other then TargetWebUrl, that will be the url of the site we want to manipulate
            Utility.AddToReadonlyQueryString(QueryString, "SPHostUrl", CurrentSharePointContext.SPHostUrl.ToString(), System.Web.HttpContext.Current.Request);
            Utility.AddToReadonlyQueryString(QueryString, "SPAppWebUrl", TargetWebURL, System.Web.HttpContext.Current.Request);
            Utility.AddToReadonlyQueryString(QueryString, "SPLanguage", CurrentSharePointContext.SPLanguage, System.Web.HttpContext.Current.Request);
            Utility.AddToReadonlyQueryString(QueryString, "SPClientTag", CurrentSharePointContext.SPClientTag, System.Web.HttpContext.Current.Request);
            Utility.AddToReadonlyQueryString(QueryString, "SPProductNumber", CurrentSharePointContext.SPProductNumber, System.Web.HttpContext.Current.Request);
            //This is a special line, we need to get the AppOnly access token and pass it along to the target site, its is a little counter intuitive
            //Because we are using TokenHelper.GetS2SAccessToeknWithWindowsIdentity - but we pass NULL as the User identity, this will 
            //check the app manifest and if the app has a CERT and AppOnly Permission it will return a valid app only token to use
            Utility.AddToReadonlyQueryString(QueryString, "AppContextToken", TokenHelper.GetS2SAccessTokenWithWindowsIdentity(new Uri(TargetWebURL), null), System.Web.HttpContext.Current.Request);
            //Return the newly created context
            return SharePointContextProvider.Current.CreateSharePointContext(HttpContext.Request, TargetWebURL).CreateAppOnlyClientContextForSPAppWeb();
        }
