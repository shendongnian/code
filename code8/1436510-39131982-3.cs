    public class UserResolverService {
        private reasonly IHttpContextAccessor accessor;
        public UserResolverService(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
    
        public string GetUser() {
            var username = accessor.HttpContext.User?.Identity?.Name ;
            return username ?? "unknown";
        }
    }
