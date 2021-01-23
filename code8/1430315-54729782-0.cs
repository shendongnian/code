@using Microsoft.AspNetCore.Http
@inject IHttpContextAccessor HttpContextAccessor
Then I added this at the location where I wanted the value of the cookie to appear:
@if (@HttpContextAccessor.HttpContext.Request.Cookies.TryGetValue("SystemDatabase", out string SystemDatabase))
{
  @SystemDatabase @:System
}
else
{
  @:Live System
}
This now prints either "Live System" or "Training System".
No changes to Startup.cs were required.
