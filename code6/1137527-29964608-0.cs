    [WebService(Namespace = "http://myapp/claims")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ClaimsWS : System.Web.Services.WebService
    {
        [WebMethod]
        public Identity GetClaims()
        {
            var principal = ClaimsPrincipal.Current;
               
            var id = new Identity
            {
                PrincipalType = principal.GetType().FullName,
                IdentityType = principal.Identity.GetType().FullName,
                   
                Claims = new List<ClaimDto>(
                    from claim in principal.Claims
                    select new ClaimDto
                    {
                        Type = claim.Type,
                        Value = claim.Value,
                        Issuer = claim.Issuer,
                        OriginalIssuer = claim.OriginalIssuer,
                    })
            };
     
            return id;
        }
    }
