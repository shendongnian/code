    /// <summary>
    /// Encapsulates fields for login request.
    /// </summary>
    /// <remarks>
    /// See: https://www.oauth.com/oauth2-servers/access-tokens/
    /// </remarks>
    public class LoginRequest
    {
        [Required]
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
    /// <summary>
    /// JWT successful response.
    /// </summary>
    /// <remarks>
    /// See: https://www.oauth.com/oauth2-servers/access-tokens/access-token-response/
    /// </remarks>
    public class AccessTokensResponse
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="AccessTokensResponse"/>.
        /// </summary>
        /// <param name="securityToken"></param>
        public AccessTokensResponse(JwtSecurityToken securityToken)
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            token_type = "Bearer";
            expires_in = Math.Truncate((securityToken.ValidTo - DateTime.UtcNow).TotalSeconds);
        }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public double expires_in { get; set; }
    }
