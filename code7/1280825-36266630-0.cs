    public class TokenController : Controller
    {
        private readonly IBearerTokenGenerator generator;
        private readonly IClientsManager clientsManager;
        private readonly IOptions<TokenAuthOptions> options;
        public TokenController(IBearerTokenGenerator generator,
            IClientsManager clientsManager,
            IOptions<TokenAuthOptions> options)
        {
            this.generator = generator;
            this.clientsManager = clientsManager;
            this.options = options;
        }
        [HttpPost, AllowAnonymous]
        public IActionResult Post(AuthenticationViewModel req)
        {
            return clientsManager
                .Find(req.client_id, req.client_secret)
                .Map(c => c.Client)
                .Map(c => (IActionResult)new ObjectResult(new {
                    access_token = generator.Generate(c),
                    expires_in = options.Value.ExpirationDelay.TotalSeconds,
                    token_type = "Bearer"
                }))
                .ValueOrDefault(HttpUnauthorized);
        }
    }
    public class BearerTokenGenerator : IBearerTokenGenerator
    {
        private readonly IOptions<TokenAuthOptions> tokenOptions;
        public BearerTokenGenerator(IOptions<TokenAuthOptions> tokenOptions)
        {
            this.tokenOptions = tokenOptions;
        }
        public string Generate(Client client)
        {
            var expires = Clock.UtcNow.Add(tokenOptions.Value.ExpirationDelay);
            var handler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new GenericIdentity(client.Identifier, "TokenAuth"), new Claim[] {
                new Claim("client_id", client.Identifier)
            });
            var securityToken = handler.CreateToken(
                issuer: tokenOptions.Value.Issuer,
                audience: tokenOptions.Value.Audience,
                signingCredentials: tokenOptions.Value.SigningCredentials,
                subject: identity,
                expires: expires);
            return handler.WriteToken(securityToken);
        }
    }
    public class ClientsManager : IClientsManager
    {
        private readonly MembershipDataContext db;
        private readonly ISecretHasher hasher;
        public ClientsManager(MembershipDataContext db,
            ISecretHasher hasher)
        {
            this.db = db;
            this.hasher = hasher;
        }
        public void Create(string name, string identifier, string secret, Company company)
        {
            var client = new Client(name, identifier, company);
            db.Clients.Add(client);
            var hash = hasher.HashSecret(secret);
            var apiClient = new ApiClient(client, hash);
            db.ApiClients.Add(apiClient);
        }
        public Option<ApiClient> Find(string identifier, string secret)
        {
            return FindByIdentifier(identifier)
                .Where(c => hasher.Verify(c.SecretHash, secret));
        }
        public void ChangeSecret(string identifier, string secret)
        {
            var client = FindByIdentifier(identifier).ValueOrDefault(() => {
                throw new ArgumentException($"could not find any client with identifier { identifier }");
            });
            var hash = hasher.HashSecret(secret);
            client.ChangeSecret(hash);
        }
        public string GenerateRandomSecret()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var generated = new string(Enumerable.Repeat(chars, 12).Select(s => s[random.Next(s.Length)]).ToArray());
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(generated));
        }
        private Option<ApiClient> FindByIdentifier(string identifier)
        {
            return db.ApiClients
                .Include(c => c.Client)
                .SingleOrDefault(c => c.Client.Identifier == identifier)
                .ToOptionByRef();
        }
    }
    public class SecretHasher : ISecretHasher
    {
        private static Company fakeCompany = new Company("fake", "fake");
        private static Client fakeClient = new Client("fake", "fake", fakeCompany);
        private readonly IPasswordHasher<Client> hasher;
        public SecretHasher(IPasswordHasher<Client> hasher)
        {
            this.hasher = hasher;
        }
        public string HashSecret(string secret)
        {
            return hasher.HashPassword(fakeClient, secret);
        }
        public bool Verify(string hashed, string secret)
        {
            return hasher.VerifyHashedPassword(fakeClient, hashed, secret) == PasswordVerificationResult.Success;
        }
    }
