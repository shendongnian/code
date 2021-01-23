        private Task<IEnumerable<Claim>> ValidateUser(string id, string secret)
        {
            if (id == secret) //Dummy validation, modify it accordingly
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
