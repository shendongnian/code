    public class TeamMemberHandler: AuthorizationHandler<PermissionRequirement>
    {
        private readonly IActionContextAccessor _accessor; // for getting teamId from RouteData
        public TeamMemberHandler(IActionContextAccessor accessor)
        {
            _accessor = accessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TeamMemberRequirement requirement)
        {
            var teamId = // get teamId with using _accessor
            if (user is not member of team(by teamId))
            {
                context.Fail();
            }
            return Task.FromResult(0);
        }
    }
    public class TeamMemberRequirement : IAuthorizationRequirement
    {
    }
