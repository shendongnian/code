        private Task<IEnumerable<System.Security.Claims.Claim>> ValidateUser(string id, string secret)
        {
            if (id == secret)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Role, "Foo")
                };
                return Task.FromResult<IEnumerable<Claim>>(claims);
            }
            return Task.FromResult<IEnumerable<Claim>>(null);
        }
