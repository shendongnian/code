    public class LoggingJwtSecurityTokenHandler : JwtSecurityTokenHandler
    {
        public override ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            try
            {
                return base.ValidateToken(securityToken, validationParameters, out validatedToken);
            }
            catch (Exception ex)
            {
                //log the error
                throw;
            }
        }
    }
