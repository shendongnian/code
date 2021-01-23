    [ApiController, Route("[controller]")]
    public class TokenController : ControllerBase
    {
        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<AccessTokensResponse>> RequestToken([FromForm]LoginRequest request)
        {
            var claims = await ValidateCredentialAndGenerateClaims(request);
            var now = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setting.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _setting.Issuer,
                audience: _setting.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_setting.ValidDurationInMinute),
                signingCredentials: signingCredentials);
            return Ok(new AccessTokensResponse(token));
        }
    }
