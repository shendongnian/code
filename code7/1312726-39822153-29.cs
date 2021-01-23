    // https://gist.github.com/pmhsfelix/4151369
    public class MyTokenHandler : Microsoft.IdentityModel.Tokens.ISecurityTokenValidator
    {
        private int m_MaximumTokenByteSize;
        public MyTokenHandler()
        { }
        bool ISecurityTokenValidator.CanValidateToken
        {
            get
            {
                // throw new NotImplementedException();
                return true;
            }
        }
        int ISecurityTokenValidator.MaximumTokenSizeInBytes
        {
            get
            {
                return this.m_MaximumTokenByteSize;
            }
            set
            {
                this.m_MaximumTokenByteSize = value;
            }
        }
        bool ISecurityTokenValidator.CanReadToken(string securityToken)
        {
            System.Console.WriteLine(securityToken);
            return true;
        }
        ClaimsPrincipal ISecurityTokenValidator.ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            // validatedToken = new JwtSecurityToken(securityToken);
            try
            {
                tokenHandler.ValidateToken(securityToken, validationParameters, out validatedToken);
                validatedToken = new JwtSecurityToken("jwtEncodedString");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
            ClaimsPrincipal principal = null;
            // SecurityToken validToken = null;
            validatedToken = null;
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
            return principal;
            throw new NotImplementedException();
        }
    }
