    @using Microsoft.AspNet.Identity;
    @using System.Threading.Tasks;
    public async Task<ActionResult> SomeMethodName(...) {
    {    
        var authenticateResult = await HttpContext.GetOwinContext()
                           .Authentication.AuthenticateAsync(
                               DefaultAuthenticationTypes.ApplicationCookie
                           );
