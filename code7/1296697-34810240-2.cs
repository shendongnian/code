    public class TokenAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
    {
        protected string SharedSecret
        {
            get { return ConfigurationManager.AppSettings["SharedSecret"]; }
        }
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                var userId = context.Request.Headers.GetValues("UserId").FirstOrDefault();
                if (userId == null)
                {
                    context.ErrorResult = new StatusCodeResult(HttpStatusCode.Forbidden, context.Request);
                    return;
                }
                var userIdToken = context.Request.Headers.GetValues("UserIdToken").FirstOrDefault();
                if (userIdToken == null)
                {
                    context.ErrorResult = new StatusCodeResult(HttpStatusCode.Forbidden, context.Request);
                    return;
                }
                var token = CreateToken(userId, SharedSecret);
                if (token != userIdToken)
                {
                    context.ErrorResult = new StatusCodeResult(HttpStatusCode.Forbidden, context.Request);
                    return;
                }
                var principal = new GenericPrincipal(new GenericIdentity(userId, "CustomIdentification"),
                    new[] {"ServiceRole"});
                context.Principal = principal;
            });
        }
        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
        }
        public bool AllowMultiple
        {
            get { return false; }
        }
        private static string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var keyByte = Encoding.ASCII.GetBytes(secret);
            var messageBytes = Encoding.ASCII.GetBytes(message);
            using (var hasher = new HMACSHA256(keyByte))
            {
                var hashmessage = hasher.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
