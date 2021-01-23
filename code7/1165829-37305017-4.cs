    using Microsoft.AspNet.Identity.EntityFramework;
    using Newtonsoft.Json;
    
    namespace Services.Models
    {
        public class TokenInfo
        {
            [JsonProperty("iss")]
            public string Issuer { get; set; }
    
            [JsonProperty("aud")]
            public string AudienceClientId { get; set; }
    
            [JsonProperty("sub")]
            public string ProviderKey { get; set; }
    
            [JsonProperty("email_verified")]
            public bool IsEmailVerifed { get; set; }
    
            [JsonProperty("azp")]
            public string AndroidClientId { get; set; }
    
            [JsonProperty("email")]
            public string Email { get; set; }
    
            [JsonProperty("iat")]
            public long IssuedAt { get; set; }
    
            [JsonProperty("exp")]
            public long ExpiresAt { get; set; }
    
            [JsonProperty("name")]
            public string Name { get; set; }
    
            [JsonProperty("picture")]
            public string Picture { get; set; }
    
            [JsonProperty("given_name")]
            public string GivenName { get; set; }
    
            [JsonProperty("family_name")]
            public string FamilyName { get; set; }
    
            [JsonProperty("locale")]
            public string Locale { get; set; }
    
            [JsonProperty("alg")]
            public string Algorithm { get; set; }
    
            [JsonProperty("kid")]
            public string kid { get; set; }
    
            public override bool Equals(object obj)
            {
                if (obj.GetType() != typeof(ApplicationUser))
                {
                    return false;
                }
    
                ApplicationUser user = (ApplicationUser)obj;
                bool hasLogin = false;
    
                foreach (IdentityUserLogin login in user.Logins)
                {
                    if (login.ProviderKey == ProviderKey)
                    {
                        hasLogin = true;
                        break;
                    }
                }
                if (!hasLogin) { return false; }
    
                if (user.FirstName != GivenName) { return false; }
                if (user.LastName != FamilyName) { return false; }
                if (user.Locale != Locale) { return false; }
    
                return base.Equals(obj);
            }
        }
    }
