    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser> {
                new InMemoryUser {
                    Subject = "1",
                    Username = "user",
                    Password = "pass123",
                    Claims = new List<Claim> {
                        new Claim(ClaimTypes.GivenName, "GivenName"),
                        new Claim(ClaimTypes.Surname, "surname"), //DELTA //.FamilyName in IdentityServer3
                        new Claim(ClaimTypes.Email, "user@somesecurecompany.com"),
                        new Claim(ClaimTypes.Role, "Badmin")
                    }
                }
            };
        }
    }
    public class Scopes
    {
        // scopes define the resources in your system
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope> {
                new Scope
                {
                    Name = "api",
                    DisplayName = "api scope",
                    Type = ScopeType.Resource,
                    Emphasize = false,
                }
            };
        }
    }
