    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                await Task.Run(
                    () =>
                        {
                            ...logging logic...
                            var claims = new List<Claim>();
                            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ExternalBearer);
                            id.AddClaim(new Claim(ClaimTypes.Role, "admin")); <--here     
                            context.Validated(id);
                        });
            }
