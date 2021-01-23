    public interface ITestService {
        Task<IdentityResult> ChangePassword(string userId, string oldPassword, string newPassword);
    }
    public abstract class MyController : ApiController {
        private ITestService service;
    
        protected MyController(ITestService service) {
            this.service = service;
        }
    
        public async Task<IHttpActionResult> ChangePassword(string NewPassword, string OldPassword) {
        
            IdentityResult result = await service.ChangePassword(User.Identity.GetUserId(), OldPassword, NewPassword);
        
            if (!result.Succeeded) {
                return GetErrorResult(result);
            }
        
            return Ok();
        }
    
    }
