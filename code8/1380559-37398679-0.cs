    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UserRepository _userRepository;
        public CustomMiddleware(RequestDelegate next, UserRepository userRepository)
        {
            _next = next;
            _userRepository = userRepository; 
        }
        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Token"];
            var user = _userRepository.Get(token);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity("Custom");
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "admin"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "admin"));
            foreach(var role in user.Roles)
            {
                claims.Add(ClaimTypes.Role, role);
            }
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            context.User = claimsPrincipal;
            await _next(context);
        }
    }
