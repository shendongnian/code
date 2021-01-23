    [WebService(Namespace = "http://myapp/claims")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ClaimsWS : System.Web.Services.WebService
    {
        [WebMethod]
        public List<ClaimValues> GetClaims()
        {
            var principal =ClaimsPrincipal.CreateFromHttpContext(HttpContext.Current); 
            return principal.Claims;
        }
    }
