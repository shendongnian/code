    public class TokenController : Controller
    {
        [Route("/token")]
        [HttpPost]
        public IActionResult Create(string username, string password)
        {
            if (IsValidUserAndPasswordCombination(username, password))
                return new ObjectResult(GenerateToken(username));
            return BadRequest();
        }
        private bool IsValidUserAndPasswordCombination(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && username == password;
        }
        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };
            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret Key You Devise")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
