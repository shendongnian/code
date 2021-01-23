    //
            // Summary:
            //     Add information to the response environment that will cause the appropriate
            //     authentication middleware to grant a claims-based identity to the recipient
            //     of the response. The exact mechanism of this may vary.  Examples include
            //     setting a cookie, to adding a fragment on the redirect url, or producing
            //     an OAuth2 access code or token response.
            //
            // Parameters:
            //   identities:
            //     Determines which claims are granted to the signed in user. The ClaimsIdentity.AuthenticationType
            //     property is compared to the middleware's Options.AuthenticationType value
            //     to determine which claims are granted by which middleware. The recommended
            //     use is to have a single ClaimsIdentity which has the AuthenticationType matching
            //     a specific middleware.
            void SignIn(params ClaimsIdentity[] identities);
            //
            // Summary:
            //     Add information to the response environment that will cause the appropriate
            //     authentication middleware to grant a claims-based identity to the recipient
            //     of the response. The exact mechanism of this may vary.  Examples include
            //     setting a cookie, to adding a fragment on the redirect url, or producing
            //     an OAuth2 access code or token response.
            //
            // Parameters:
            //   properties:
            //     Contains additional properties the middleware are expected to persist along
            //     with the claims. These values will be returned as the AuthenticateResult.properties
            //     collection when AuthenticateAsync is called on subsequent requests.
            //
            //   identities:
            //     Determines which claims are granted to the signed in user. The ClaimsIdentity.AuthenticationType
            //     property is compared to the middleware's Options.AuthenticationType value
            //     to determine which claims are granted by which middleware. The recommended
            //     use is to have a single ClaimsIdentity which has the AuthenticationType matching
            //     a specific middleware.
            void SignIn(AuthenticationProperties properties, params ClaimsIdentity[] identities);
