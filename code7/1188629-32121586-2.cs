    [Route("[AreaPrefix]/[ControllerPrefix]")
    public class HomeOps : Controller // Controller Suffix is optional
    {
    }
    [Route("api")]
    public class HomeApiOps : HomeOps
    {
         // put the api AJAX methods here
         [HttpPost("lookup")] // will route to // AreaPrefix/ControllerPrefix/api/lookup
         public IActionResult Lookup() {
    }
    public class HomePageOps : HomeOps
    {
         // put similar routes for View returns, file content responses here
         [HttpPost("lookup")] // Will route to AreaPrefix/ControllerPrefix/lookup
         public IActionResult Lookup() {
    }
