    class CustomGoogleAuthProvider : GoogleOAuth2AuthenticationProvider
    {
        public CustomGoogleAuthProvider()
        {
            OnApplyRedirect = (GoogleOAuth2ApplyRedirectContext context) =>
            {
                IDictionary<string, string> props = context.OwinContext.Authentication.AuthenticationResponseChallenge.Properties.Dictionary;
    
                string newRedirectUri = context.RedirectUri;
    
                string[] paramertsToPassThrough = new[] { "login_hint", "hd", "anything" };
                
                foreach (var param in paramertsToPassThrough)
                {
                    if (props.ContainsKey(param))
                    {
                        newRedirectUri += string.Format("&{0}={1}", param, HttpUtility.UrlEncode(props[param]));
                    }
                }
    
                context.Response.Redirect(newRedirectUri);
            };
        }
    }
