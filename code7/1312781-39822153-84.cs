    public class CustomJwtDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string algorithm;
        private readonly TokenValidationParameters validationParameters;
        public CustomJwtDataFormat(string algorithm, TokenValidationParameters validationParameters)
        {
            this.algorithm = algorithm;
            this.validationParameters = validationParameters;
        }
        
        // This ISecureDataFormat implementation is decode-only
        string ISecureDataFormat<AuthenticationTicket>.Protect(AuthenticationTicket data)
        {
            return MyProtect(data, null);
        }
        string ISecureDataFormat<AuthenticationTicket>.Protect(AuthenticationTicket data, string purpose)
        {
            return MyProtect(data, purpose);
        }
        AuthenticationTicket ISecureDataFormat<AuthenticationTicket>.Unprotect(string protectedText)
        {
            return MyUnprotect(protectedText, null);
        }
        AuthenticationTicket ISecureDataFormat<AuthenticationTicket>.Unprotect(string protectedText, string purpose)
        {
            return MyUnprotect(protectedText, purpose);
        }
        private string MyProtect(AuthenticationTicket data, string purpose)
        {
            return "wadehadedudada";
            throw new System.NotImplementedException();
        }
        // http://blogs.microsoft.co.il/sasha/2012/01/20/aggressive-inlining-in-the-clr-45-jit/
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private AuthenticationTicket MyUnprotect(string protectedText, string purpose)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = null;
            SecurityToken validToken = null;
            System.Collections.Generic.List<System.Security.Claims.Claim> ls = 
                new System.Collections.Generic.List<System.Security.Claims.Claim>();
            ls.Add(
                new System.Security.Claims.Claim(
                    System.Security.Claims.ClaimTypes.Name, "IcanHazUsr_éèêëïàáâäåãæóòôöõõúùûüñçø_ÉÈÊËÏÀÁÂÄÅÃÆÓÒÔÖÕÕÚÙÛÜÑÇØ 你好，世界 Привет\tмир"
                , System.Security.Claims.ClaimValueTypes.String
                )
            );
            // 
            System.Security.Claims.ClaimsIdentity id = new System.Security.Claims.ClaimsIdentity("authenticationType");
            id.AddClaims(ls);
            principal = new System.Security.Claims.ClaimsPrincipal(id);
            return new AuthenticationTicket(principal, new AuthenticationProperties(), "MyCookieMiddlewareInstance");
            try
            {
                principal = handler.ValidateToken(protectedText, this.validationParameters, out validToken);
                JwtSecurityToken validJwt = validToken as JwtSecurityToken;
                if (validJwt == null)
                {
                    throw new System.ArgumentException("Invalid JWT");
                }
                if (!validJwt.Header.Alg.Equals(algorithm, System.StringComparison.Ordinal))
                {
                    throw new System.ArgumentException($"Algorithm must be '{algorithm}'");
                }
                // Additional custom validation of JWT claims here (if any)
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }
            catch (System.ArgumentException)
            {
                return null;
            }
            // Validation passed. Return a valid AuthenticationTicket:
            return new AuthenticationTicket(principal, new AuthenticationProperties(), "MyCookieMiddlewareInstance");
        }
    }
