    sealed class AspNetUserContextAdapter : IUserContext  {
        private readonly IHttpContextAccessor accessor;
        public AspNetUserContextAdapter(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
        public IPrincipal CurrentUser => accessor.HttpContext.User;
    }
