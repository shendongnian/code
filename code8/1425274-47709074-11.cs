    public class AccountController : Controller
    {
        [ProducesResponseType(typeof(AccessTokens), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[HttpPost("/token")]
		public async Task<IActionResult> Token([FromForm] LoginModel loginModel)
		{
			switch (loginModel.grant_type)
			{
				case "password":
                    var accessTokens = // Authentication logic
                    if (accessTokens == null)
                        return BadRequest("Invalid user name or password.");
                    return new ObjectResult(accessTokens);
		
				case "refresh_token":
                    var accessTokens = // Refresh token logic
                    if (accessTokens == null)
                        return Unauthorized();
                    return new ObjectResult(accessTokens);
		
				default:
					return BadRequest("Unsupported grant type");
			}
		}
    }
    public class LoginModel
    {
        [Required]
        public string grant_type { get; set; }
    
        public string username { get; set; }
        public string password { get; set; }
        public string refresh_token { get; set; }
        // Optional
        //public string scope { get; set; }
    }
    public class AccessTokens
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
