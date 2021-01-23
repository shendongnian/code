    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [HttpPost("/token")]
    public async Task<IActionResult> Token([FromForm] LoginModel loginModel)
    {
        switch (loginModel.grant_type)
        {
            case "password":
    			// Some logic
    
            case "refresh_token":
    			// Some logic
    
            default:
                return BadRequest("Unsupported grant type");
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
