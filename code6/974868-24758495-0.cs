    GlobalRequestFilters.Add((req, res, requestDto) => {
        // Check for the session cookie
        const string cookieName = "auth";
        var sessionCookie = req.GetCookieValue(cookieName);
        if(sessionCookie != null)
        {
            // Try authenticate using the session cookie
            var cache = req.GetCacheClient();
            var session = cache.Get<MySession>(sessionCookie);
            if(session != null && session.Expires > DateTime.Now)
            {
                // Session is valid permit the request
                return;
            }
        }
        // Fallback to checking the client certificate
        var originalRequest = req.OriginalRequest as ListenerRequest;
        if(originalRequest != null)
        {
            // Get the certificate from the request
            var certificate = originalRequest.HttpRequest.GetClientCertificate();
            /*
             * Check the certificate is valid
             * (Replace with your own checks here)
             * You can do this by checking a database of known certificate serial numbers or the public key etc.
             * 
             * If you need database access you can resolve it from the container
             * var db = HostContext.TryResolve<IDbConnection>();
             */
            bool isValid = certificate != null && certificate.SerialNumber == "XXXXXXXXXXXXXXXX";
            // Handle valid certificates
            if(isValid)
            {
                // Create a session for the user
                var sessionId = SessionExtensions.CreateRandomBase64Id();
                var expiration = DateTime.Now.AddHours(1);
                var session = new MySession {
                    Id = sessionId,
                    Name = certificate.SubjectName,
                    ClientCertificateSerialNumber = certificate.SerialNumber,
                    Expires = expiration
                };
                // Add the session to the cache
                var cache = req.GetCacheClient();
                cache.Add<MySession>(sessionId, session);
                // Set the session cookie
                res.SetCookie(cookieName, sessionId, expiration);
                // Permit the request
                return;
            }
        }
        // No valid session cookie or client certificate
        throw new HttpError(System.Net.HttpStatusCode.Unauthorized, "401", "A valid client certificate or session is required");
    });
