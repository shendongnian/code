    using Newtonsoft.Json.Linq;  // this gets you to JObject
    [Route("svc/[controller]/[action]")]
    public class AccountController : Controller
    {
      [HttpPost("{accountid}")]
      public IActionResult UpdateAccount(int accountid, [FromBody]JObject payload)
      {
        var loginToken = payload["logintoken"].ToObject<LoginToken>();
        var newAccount = payload["account"].ToObject<Account>();
        // perform update
        return this.Ok("success");
      }
    }
