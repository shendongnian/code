    public abstract class MyController : ApiController {
        private ITestService service;
    
        protected MyController(ITestService service) {
            this.service = service;
        }
    
        public async Task<IHttpActionResult> ChangePassword(string NewPassword, string OldPassword) {
        
            IdentityResult result = await _service.ChangePassword(User.Identity.GetUserId(), OldPassword, NewPassword);
        
            if (!result.Succeeded) {
                return GetErrorResult(result);
            }
        
            return Ok();
        }
    
    }
