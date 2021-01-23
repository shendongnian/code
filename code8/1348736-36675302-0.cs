    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenAuthOptions _tokenOptions;
        public TokenController(TokenAuthOptions tokenOptions, UserManager<ApplicationUser> userManager)
        {
            _tokenOptions = tokenOptions;
            _userManager = userManager;
        }
        public class AuthRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        [HttpPost]
        public async Task<dynamic> Post([FromBody] AuthRequest req)
        {
            var user = await _userManager.FindByNameAsync(req.Username);
            if (await _userManager.CheckPasswordAsync(user, req.Password))
            {
                DateTime? expires = DateTime.UtcNow.AddMinutes(2);
                var token = GetToken(req.Username, expires, user);
                return new { authenticated = true, entityId = user.Id, token = token, tokenExpires = expires };
            }
            return new { authenticated = false };
        }
        private async Task<string> GetToken(string userName, DateTime? expires, ApplicationUser user)
        {
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                signingCredentials: _tokenOptions.SigningCredentials,
                subject: new ClaimsIdentity(await _userManager.GetClaimsAsync(user)),
                expires: expires
                );
            return handler.WriteToken(securityToken);
        }
    }
